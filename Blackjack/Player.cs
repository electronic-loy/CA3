using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        //This was made by ChatGPT

        public List<Card> Hand { get; private set; }
        public int Score => CalculateScore();
        public bool IsBust => Score > 21;

        public Player()
        {
            Hand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            if (card != null)
            {
                Hand.Add(card);
            }
        }

        private int CalculateScore()
        {
            int total = 0;
            int aceCount = 0;

            foreach (var card in Hand)
            {
                total += card.PointValue;
                if (card.PointValue == 11) // Ace
                {
                    aceCount++;
                }
            }

            // Adjust for Aces if total > 21
            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }

            return total;
        }

        public void ShowHand()
        {
            Console.WriteLine("Player's Hand:");
            foreach (var card in Hand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine($"Total Score: {Score}");
        }
    }
}
