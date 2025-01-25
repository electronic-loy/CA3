using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Introducing the phenomenal option to read the rules!
            // And Spanish Localization!
            // Asking for language preference


            Console.WriteLine("Bem-vindo ao Blackjack!");
            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("¡Bienvenidos a Blackjack!");
            Console.WriteLine("\nSelecione o seu idioma (prima 1, 2 ou 3) / Select your language (press 1, 2 or 3) / Selecciona el idioma (pulsa 1 o 2):\n");
            Console.WriteLine("1. Português");
            Console.WriteLine("2. English");
            Console.WriteLine("3. Español");
            string languageChoice = Console.ReadLine();
            string language = languageChoice switch
            {
                "1" => "pt-PT",
                "2" => "en",
                "3" => "es",
                _ => "en" // Default to English
            };

            // Initialize translations
            Translations translations = new Translations(language);

            Console.Clear();
            Console.WriteLine(translations.Get("welcome"));

            Console.Clear();

            //Asking to read the instructions

            if (language == "pt-PT")
            {
                Console.WriteLine("Deseja ler as regras antes de começar? (s/n)");
            }
            else if (language == "es")
            {
                Console.WriteLine("¿Te gustaría leer las reglas antes de empezar? (s/n)");
            }
            else if (language == "en")
            {
                Console.WriteLine("Would you like to read the rules before starting? (y/n)");
            }

            string readRules = Console.ReadLine()?.ToLower();

            if ((language == "pt-PT" && readRules == "s") || (language == "es" && readRules == "s") || (language == "en" && readRules == "y"))
            {
                Rules.Display(language);
                if (language == "pt-PT")
                {
                    Console.WriteLine("Prima Enter para iniciar o jogo...");
                }
                else if (language == "es")
                {
                    Console.WriteLine("Presiona Enter para comenzar el juego...");
                }
                else
                {
                    Console.WriteLine("Press Enter to start the game...");
                }
                Console.ReadLine();
                Console.Clear();
            }



            //22nd Jan, I'm introducing a loop in which the game keeps on until the player quits and then gives a final balance

            int wins = 0, losses = 0;
            int playerBalance = 100; // Starting balance
            bool keepPlaying = true; // I love bools

            Console.Clear();
            Deck deck = new Deck();
            deck.Shuffle();

            // New on 22nd Jan, since I want the game to go on, now
            // if the deck has less than 10 cards it reshuffles!
            // this was asked to do to Chat GPT

            while (keepPlaying)
            {
                if (deck.RemainingCards < 10) // Reshuffle when low on cards
                {
                    Console.WriteLine(translations.Get("reshuffle"));
                    deck = new Deck();
                    deck.Shuffle();
                }

                Player player = new Player(translations);
                Dealer dealer = new Dealer(translations);

                // Betting (added 22nd Jan)
                Console.WriteLine(translations.Get("placeBet"), playerBalance);
                int bet;
                while (!int.TryParse(Console.ReadLine(), out bet) || bet <= 0 || bet > playerBalance)
                {
                    Console.WriteLine(translations.Get("invalidBet"));
                }

                // Initial deal
                player.AddCard(deck.DealCard());
                player.AddCard(deck.DealCard());

                dealer.AddCard(deck.DealCard());
                dealer.AddCard(deck.DealCard());

                // Show initial cards
                player.ShowHand();
                dealer.ShowInitialCard();

                // First additional rule, Blackjack (two cards that sum 21)

                if (player.HasBlackjack)
                {
                    if (dealer.HasBlackjack)
                    {
                        Console.WriteLine(translations.Get("tieBlackjack"));
                    }
                    else
                    {
                        Console.WriteLine(translations.Get("playerBlackjack"));
                        wins++;
                        playerBalance += bet;
                    }
                    Console.WriteLine(translations.Get("playAgain"));
                    keepPlaying = Console.ReadLine()?.ToLower() == "s" || (language == "en" && Console.ReadLine()?.ToLower() == "y");

                    if (keepPlaying)
                    {
                        Console.Clear();
                    }
                    else
                    {
                        break; // Exit the game loop if the player doesn't want to continue
                    }

                    continue; // Continue to the next game round if the player wants to play again

                }

                // Player's turn (mainly ChatGPT)
                // I have "twisted" the choices up a bit

                // 22nd January, I have added double down, but it can only be used on the first turn, therefore I implemented a first turn

                bool isFirstTurn = true;
                while (!player.IsBust)
                {
                    if (isFirstTurn)
                    {
                        Console.WriteLine(translations.Get("playerChoiceFirst"));
                    }
                    else
                    {
                        Console.WriteLine(translations.Get("playerChoice"));
                    }

                    string choice = Console.ReadLine()?.ToLower();

                    if (choice == "d" && isFirstTurn) // Double Down
                    {
                        // This if was done by Chat GPT
                        if (playerBalance < bet * 2)
                        {
                            Console.WriteLine(translations.Get("noDoubleBalance"));
                            continue;
                        }
                        bet *= 2; // Double the bet

                        var newCard = deck.DealCard();
                        player.AddCard(newCard);

                        Console.WriteLine(translations.Get("doubleDown"), player.Score);
                        if (player.IsBust)
                        {
                            Console.WriteLine(translations.Get("busted"));
                        }
                        break; // End turn after doubling down
                    }
                    else if (choice == "t")
                    {
                        // Deal one card to the player
                        // Before it was showing the whole hand again, now it should only be card by card
                        var newCard = deck.DealCard();
                        player.AddCard(newCard);
                        Console.WriteLine(translations.Get("dealtCard"), newCard.ToString(translations), player.Score);
                    }
                    else if (choice == "s")
                    {
                        break;
                    }

                    // Invalid input wasn't handled before, so I just added it
                    else
                    {
                        Console.WriteLine(translations.Get("invalidChoice"));
                    }
                    isFirstTurn = false; // Disable double down after the first turn
                }

                if (player.IsBust)
                {
                    Console.WriteLine(translations.Get("busted"));
                    losses++;
                    playerBalance -= bet;
                    Console.WriteLine(translations.Get("gameStats"), wins, losses, playerBalance);

                    if (playerBalance <= 0)
                    {
                        Console.WriteLine(translations.Get("outOfMoney"));
                        keepPlaying = false;
                        break;
                    }

                    Console.WriteLine(translations.Get("playAgain"));
                    keepPlaying = Console.ReadLine()?.ToLower() == (language == "es" ? "s" : "y");
                    if (keepPlaying)
                    {
                        Console.Clear();
                    }
                    continue; // Skip the dealer's turn since the player lost
                }

                // Dealer's turn
                while (dealer.ShouldHit())
                {
                    dealer.AddCard(deck.DealCard());
                }
                dealer.ShowDealerHand();

                // New way to determine the winner
                // that also adds a counter to wins or losses.
                // Inspired by one exercise where we used the ++ a lot

                if (dealer.IsBust || player.Score > dealer.Score)
                {
                    Console.WriteLine(translations.Get("playerWin"));
                    wins++;
                    playerBalance += bet;
                }
                else if (player.Score < dealer.Score)
                {
                    Console.WriteLine(translations.Get("dealerWin"));
                    losses++;
                    playerBalance -= bet;
                }
                else
                {
                    Console.WriteLine(translations.Get("tie"));
                }

                Console.WriteLine(translations.Get("gameStats"), wins, losses, playerBalance);

                // By Chat GPT:
                if (playerBalance <= 0)
                {
                    Console.WriteLine(translations.Get("outOfMoney"));
                    break;
                }

                Console.WriteLine(translations.Get("playAgain"));
                keepPlaying = Console.ReadLine()?.ToLower() == "s" || (language == "en" && Console.ReadLine()?.ToLower() == "y");

                if (keepPlaying)
                {
                    Console.Clear();
                }

                Console.WriteLine("Thanks for playing!");
            }
        }
    }
}
