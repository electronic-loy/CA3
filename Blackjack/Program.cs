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
            //Basic blackjack with 1 extra rule

            Deck deck = new Deck();
            deck.Shuffle();

            Player player = new Player();
            Dealer dealer = new Dealer();

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
                }
                return;
            }

            // Player's turn (mainly ChatGPT)
            // I have "twisted" the choices up a bit

            //I haven´t faced any bugs today

            while (!player.IsBust)
            {
                Console.WriteLine("Do you want to Stick or Twist? (s/t)");
                
                string choice = Console.ReadLine()?.ToLower();

                if (choice == "t")
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
                    Console.WriteLine("Oopsy doopsy! Invalid choice! Please enter 's' to Stick or 't' to Twist.");
                }
            }

            if (player.IsBust)
            {
                Console.WriteLine("Player busted! Dealer wins.");
                return;
            }

            // Dealer's turn
            while (dealer.ShouldHit())
            {
                dealer.AddCard(deck.DealCard());
            }
            dealer.ShowFullHand();

            // Determine winner
            if (dealer.IsBust || player.Score > dealer.Score)
            {
                Console.WriteLine("Player wins!");
            }
            else if (player.Score < dealer.Score)
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }



        }
    }
}
    

