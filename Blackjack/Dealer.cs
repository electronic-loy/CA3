using System;
using System.Collections;
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
        public Dealer(Translations translations) : base(translations) { }

        public void ShowInitialCard()
        {
            if (Hand.Count > 0)
            {
                // Replace "dealerShows" with the translation key
                Console.WriteLine($"{translations.Get("dealerShows")}: {Hand[0].ToString(translations)}");
            }
        }

        public void ShowDealerHand()
        {
            // Use translation for "dealerHand"
            Console.WriteLine(translations.Get("dealerHand"));
            Console.WriteLine(translations.Get("pressKey")); // "Press any key to continue..."
            Console.ReadKey();

            foreach (var card in Hand)
            {
                // Use translation for "card"
                Console.WriteLine(translations.Get("card") + ": " + card.ToString(translations)); // Display the card details
            }
        }

        //I implemented the specific general rule of the 16 points (the dealer needs to reach at least 17 points and if it's 16 he still plays)
        //Soft 17 rule will be implemented soon

        public bool ShouldHit()
        {
            return Score < 17;
        }
    }
}
