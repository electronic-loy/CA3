using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer : Player
    {
        public void ShowInitialCard()
        {
            if (Hand.Count > 0)
            {
                Console.WriteLine($"Dealer shows: {Hand[0]}");
            }
        }

        public void ShowFullHand()
        {
            Console.WriteLine("Dealer's Full Hand:");
            foreach (var card in Hand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine($"Total Score: {Score}");
        }

        public bool ShouldHit()
        {
            return Score < 17;
        }
    }
}
