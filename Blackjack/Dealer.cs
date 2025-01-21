using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Dealer : Player
    {
        // This Dealer class takes most of the behaviour from Player so I have inherited it.
        // Now updating both classes is easier, especially since I started adding the additional rules.
        // The rest is usually also very close to the player way

        public void ShowInitialCard()
        {
            if (Hand.Count > 0)
            {
                Console.WriteLine($"Dealer shows: {Hand[0]}");
            }
        }

        public void ShowFullHand()
        {
            Console.WriteLine("Dealer's Hand: (press any key to show the next action)");
            foreach (var card in Hand)
            {
                Console.WriteLine(card);
                
                //I have included ReadKey to make it feel more interactive
                //and more like a videogame where you press a button for the next text.
                //It also makes it more intriguing.

                Console.ReadKey();
            }
            Console.WriteLine($"Total Score: {Score}");
        }

        //I implemented the specific rule of the 16 points
        //Soft 17 rule will be implemented soon

        public bool ShouldHit()
        {
            return Score < 17;
        }
    }
}
