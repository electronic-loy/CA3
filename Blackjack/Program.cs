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


            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("¡Bienvenidos a Blackjack!");
            Console.WriteLine("Please select your language (press 1 or 2) / Selecciona el idioma (pulsa 1 o 2):");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Español");
            string languageChoice = Console.ReadLine();
            string language = languageChoice == "2" ? "es" : "en";

            // Initialize translations
            Translations translations = new Translations(language);

            Console.Clear();
            Console.WriteLine(translations.Get("welcome"));

            Console.Clear();

            if (language == "en")
            {
                Console.WriteLine("Would you like to read the rules before starting? (y/n)");
            }
            else
            {
                Console.WriteLine("¿Te gustaría leer las reglas antes de empezar? (s/n)");
            }
            string readRules = Console.ReadLine()?.ToLower();

            if ((language == "en" && readRules == "y") || (language == "es" && readRules == "s"))
            {
                Rules.Display(language);
                Console.WriteLine(language == "en" ? "Press Enter to start the game..." : "Presiona Enter para comenzar el juego...");
                Console.ReadLine();
                Console.Clear();
            }

            Console.Clear();
            Console.WriteLine(translations.Get("startingBalance"));

            //22nd Jan, I'm introducing a loop in which the game keeps on until the player quits and then gives a final balance

            int wins = 0, losses = 0;
            int playerBalance = 100; // Starting balance
            bool keepPlaying = true; // I love bools

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
                    continue;
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

                        Console.WriteLine($"You were dealt: {newCard}");
                        Console.WriteLine(translations.Get("dealtCard"), newCard, player.Score);
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
                keepPlaying = Console.ReadLine()?.ToLower() == (language == "es" ? "s" : "y");

                if (keepPlaying)
                {
                    Console.Clear();
                }
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
