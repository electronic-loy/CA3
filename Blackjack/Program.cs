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
            //Basic blackjack with no extra rules

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

            // Player's turn (ChatGPT)

            //There is a bug where sometimes the card value is not added, I need to fix that

            while (!player.IsBust)
            {
                Console.WriteLine("Do you want to Stick or Twist? (s/t)");
                string choice = Console.ReadLine()?.ToLower();

                if (choice == "t")
                {
                    player.AddCard(deck.DealCard());
                    player.ShowHand();
                }
                else if (choice == "s")
                {
                    break;
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
    

