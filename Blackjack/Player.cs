using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Player
    {
        //This was made originally by ChatGPT as on the previous "sending"
        //Of course I have added now my personal touch and added more comments.

        public List<Card> Hand { get; private set; }
        public int Score => CalculateScore();
        public bool IsBust => Score > 21;

        protected Translations translations;
        private bool hasAce; // Tracks if the player has an Ace instead of counting them, because we only need 1
        //I added it as a boolean on purpose

        //New Bool also added to have more bools, and this time concerning one of the extra rules.
        //This bool was designed by Chat GPT, couldn't think how to improve it
        public bool HasBlackjack => Hand.Count == 2 && Score == 21;

        public Player(Translations translations)
        {
            Hand = new List<Card>();
            hasAce = false;
            this.translations = translations; // Store the translation dictionary
        }

        public void AddCard(Card card)
        {
            if (card != null)
            {
                Hand.Add(card);
                //instead of including the Ace boolean in CalculateScore
                //I added it here
                if (card.PointValue == 11) // If the card is an Ace
                {
                    hasAce = true;
                }
            }
        }

        private int CalculateScore()
        {
            int total = 0;
            

            foreach (var card in Hand)
            {
                total += card.PointValue;
            }

            // Now we adjust Aces if total > 21
            // if the total is more than 21 and there is an Ace,
            // it automatically substracts 10 points

            while (total > 21 && hasAce)
            {
                total -= 10;
            }

            return total;
        }

        public void ShowHand()
        {
            // Replace "playerHand" with the translation key
            Console.WriteLine(translations.Get("playerHand"));
            Console.WriteLine(translations.Get("pressKey")); // "Press any key to continue..."
            Console.ReadKey();

            foreach (var card in Hand)
            {
                Console.WriteLine(card.ToString(translations)); // Display the card details
            }

            // Replace "totalScore" with the translation key
            Console.WriteLine($"{translations.Get("totalScore")}: {Score}");
        }

    }
}
