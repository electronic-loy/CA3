using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        //This is a simple Card class, very "atomic",
        //I have used for reference this video after looking at various options
        //https://www.youtube.com/watch?v=pd9vtszpGZg&ab_channel=SirJosephthePaladin

        private string face;
        private string suit;

        public Card(string cardFace, string cardSuit)
        {
            face = cardFace;
            suit = cardSuit;
        }

        public override string ToString()
        {
            return face + " of " + suit;
        }

        //I have started again so most of what was here in DevJournal1 was moved to Deck

        // Property to calculate point value

        //A switch statement allows me to avoid having to assign points manually
        public int PointValue
        {
            get
            {
                switch (face)
                {
                    case "Ace":
                        return 11; // Default value is 11
                    case "King":
                    case "Queen":
                    case "Jack":
                        return 10;
                    default:
                        return int.Parse(face); // Numeric cards return their face value.
                }
            }
        }




    }
}
