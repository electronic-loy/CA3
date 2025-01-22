using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public static class Rules
    {
        // Display the rules of Blackjack
        public static void Display()
        {
            Console.WriteLine("\nBLACKJACK RULES:");
            Console.WriteLine("1. The goal is to get as close to 21 as possible without going over.");
            Console.WriteLine("2. Number cards are worth their face value.");
            Console.WriteLine("3. Face cards (King, Queen, Jack) are worth 10 points.");
            Console.WriteLine("4. Aces can be worth 1 or 11 points, whichever is more beneficial.");
            Console.WriteLine("5. Both the player and the dealer are dealt two cards initially.");
            Console.WriteLine("6. The player can 'Twist' to take another card or 'Stick' to stop.");
            Console.WriteLine("7. The player can 'Double Down' on the first turn, doubling the bet and taking one more card.");
            Console.WriteLine("8. The dealer must 'Stick' on 17 or higher and 'Twist' on 16 or lower.");
            Console.WriteLine("9. If your total exceeds 21, you go 'Bust' and lose the round.");
            Console.WriteLine("10. If both you and the dealer have the same score, it's a tie.\n");
        }
    }
}
