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
            //It's Blackjack time

            //I start by declaring the cards (useless after I made the Card class)
            string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] suits = { "Clubs", "Diamonds", "Spades", "Hearts" };

            double numberOfCards = 52;

            foreach (string card in cards)
            {
                Console.WriteLine(card);

            }
            Deck deck = new Deck();
            deck.FillDeck();
            deck.PrintDeck();


        }
    }
}
