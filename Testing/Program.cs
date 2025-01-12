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
            Deck deck = new Deck();
            deck.Shuffle();

            // Dealing cards and showing point values
            for (int i = 0; i < 5; i++) // Deal 5 cards as an example
            {
                Card dealtCard = deck.DealCard(); // No re-declaration of 'deck'
                Console.WriteLine($"{dealtCard} has {dealtCard.PointValue} points.");
            }

            Console.ReadLine();
        }

        ////Commenting out, this part is to check if the Deck shuffles correctly
        //Console.WriteLine("Shuffled deck:");
        //for (int i = 0; i < 52; i++)
        //{
        //    Card dealtCard = deck.DealCard();
        //    if (dealtCard != null)
        //    {
        //        Console.WriteLine(dealtCard.ToString());
        //    }
        //    else
        //    {
        //        Console.WriteLine("No more cards to deal!");
        //    }
        //}



    }
}


