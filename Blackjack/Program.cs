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

            Console.WriteLine("Welcome to Blackjack!");
            Console.WriteLine("Would you like to read the rules before starting? (y/n)");
            string readRules = Console.ReadLine()?.ToLower();

            if (readRules == "y")
            {
                Rules.Display();
                Console.WriteLine("Press Enter to start the game...");
                Console.ReadLine();
                Console.Clear();
            }

            //22nd Jan, I'm introducing a some kind of loop in which the game keeps on until the player quits and then gives a final balance

            int wins = 0, losses = 0;
            int playerBalance = 100; // Starting balance
            bool keepPlaying = true; // I love bools

            Deck deck = new Deck();
            deck.Shuffle();

            //New on 22nd Jan, since I want the game to go on, now
            // if the deck has less than 10 cards it reshuffles!
            // this was asked to do to Chat GPT

            while (keepPlaying)
            {
                if (deck.RemainingCards < 10) // Reshuffle when low on cards
                {
                    Console.WriteLine("Reshuffling the deck...");
                    deck = new Deck();
                    deck.Shuffle();
                }

                Player player = new Player();
                Dealer dealer = new Dealer();

                //Betting (added 22nd Jan)
                Console.WriteLine($"Enter your bet. Your current balance is: {playerBalance}");
                int bet;
                while (!int.TryParse(Console.ReadLine(), out bet) || bet <= 0 || bet > playerBalance)
                {
                    Console.WriteLine("Invalid bet. Please enter a positive number within your balance.");
                }

                // Initial deal
                player.AddCard(deck.DealCard());
                player.AddCard(deck.DealCard());

                dealer.AddCard(deck.DealCard());
                dealer.AddCard(deck.DealCard());

                // Show initial cards
                player.ShowHand();
                dealer.ShowInitialCard();

                //First additional rule, Blackjack (two cards that sum 21)

                if (player.HasBlackjack)
                {
                    if (dealer.HasBlackjack)
                    {
                        Console.WriteLine("It's a tie! Both have Blackjack.");
                    }
                    else
                    {
                        Console.WriteLine("Player wins with a Blackjack!");
                        wins++;
                        playerBalance += bet;
                    }
                    continue;
                }

                // Player's turn (mainly ChatGPT)
                // I have "twisted" the choices up a bit

                //22nd January, I have added double down, but it can only be used on the first turn, therefore I implemented a first turn

                bool isFirstTurn = true;
                while (!player.IsBust)
                {
                    if (isFirstTurn)
                    {
                        Console.WriteLine("Do you want to Stick, Twist, or Double Down? (s/t/d)");
                    }
                    else
                    {
                        Console.WriteLine("Do you want to Stick or Twist? (s/t)");
                    }

                        string choice = Console.ReadLine()?.ToLower();

                    if (choice == "d" && isFirstTurn) // Double Down
                    {
                        //This if was done by Chat GPT
                        if (playerBalance < bet * 2)
                        {
                            Console.WriteLine("You don't have enough balance to double down.");
                            continue;
                        }
                        bet *= 2; // Double the bet

                        var newCard = deck.DealCard();
                        player.AddCard(newCard);
                        Console.WriteLine($"You doubled down and were dealt: {newCard}");
                        Console.WriteLine($"Your final score: {player.Score}");

                        if (player.IsBust)
                        {
                            Console.WriteLine("You're double bust!");
                        }
                        break; // End turn after doubling down
                    }
                    else if (choice == "t")
                    {
                        // Deal one card to the player
                        //Before it was showing the whole hand again, now it should only be card by card
                        var newCard = deck.DealCard();
                        player.AddCard(newCard);

                        Console.WriteLine($"You were dealt: {newCard}");
                        Console.WriteLine($"Your current score: {player.Score}");
                    }
                    else if (choice == "s")
                    {
                        break;
                    }

                    // Invalid input wasn't handled before, so I just added it

                    else
                    {
                        Console.WriteLine("Oopsy doopsy! Invalid choice! Please enter 's' to Stick or 't' to Twist, or 'd' to Double Down (if you can)");
                    }
                    isFirstTurn = false; // Disable double down after the first turn
                }

                if (player.IsBust)
                {
                    Console.WriteLine("Player busted! Dealer wins, muaaaaaaahahaaaaaaaa!!");
                    losses++;
                    playerBalance -= bet;

                    Console.WriteLine($"\nWins: {wins}, Losses: {losses}");
                    Console.WriteLine($"Your balance: {playerBalance}");

                    if (playerBalance <= 0)
                    {
                        Console.WriteLine("You're out of money! Game over.");
                        break;
                    }

                    Console.WriteLine("Do you want to play again? (y/n)");
                    string response = Console.ReadLine()?.ToLower();
                    keepPlaying = response == "y";
                    if (keepPlaying)
                    {
                        Console.Clear();
                    }
                    continue;
                }

                // Dealer's turn
                while (dealer.ShouldHit())
                {
                    dealer.AddCard(deck.DealCard());
                }
                dealer.ShowFullHand();


                // New way to determine the winner
                // that also adds a counter to wins or losses.
                // Inspired by one exercise where we used the ++ a lot
                if (player.IsBust)
                {
                    Console.WriteLine("You lose!");
                    losses++;
                    playerBalance -= bet;
                }
                else if (dealer.IsBust || player.Score > dealer.Score)
                {
                    Console.WriteLine("You win!");
                    wins++;
                    playerBalance += bet;
                }
                else if (player.Score < dealer.Score)
                {
                    Console.WriteLine("You lose!");
                    losses++;
                    playerBalance -= bet;
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }

                Console.WriteLine($"\nWins: {wins}, Losses: {losses}");
                Console.WriteLine($"Your balance: {playerBalance}");

                // By Chat GPT:

                if (playerBalance <= 0)
                {
                    Console.WriteLine("You're out of money! Game over.");
                    break;
                }

                Console.WriteLine("Do you want to play again? (y/n)");
                string playAgain = Console.ReadLine()?.ToLower();
                keepPlaying = playAgain == "y";
                if (keepPlaying)
                {
                    Console.Clear();
                }
            }

            Console.WriteLine("Thanks for playing!");
        }

    }
}



