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
        public static void Display(string language)
        {
            if (language == "en")
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
            else if (language == "es")
            {
                Console.WriteLine("\nREGLAS DEL BLACKJACK:");
                Console.WriteLine("1. El objetivo es acercarse lo más posible a 21 sin pasarse.");
                Console.WriteLine("2. Las cartas numéricas valen su valor nominal.");
                Console.WriteLine("3. Las cartas de figura (Rey, Reina, Jota) valen 10 puntos.");
                Console.WriteLine("4. Los Ases pueden valer 1 o 11 puntos, según convenga.");
                Console.WriteLine("5. Tanto el jugador como el crupier reciben dos cartas inicialmente.");
                Console.WriteLine("6. El jugador puede pedir carta o quedarse.");
                Console.WriteLine("7. El jugador puede doblar la apuesta en el primer turno, y luego recibe una carta más.");
                Console.WriteLine("8. El crupier debe quedarse con 17 o más y pedir carta con 16 o menos.");
                Console.WriteLine("9. Si tu total supera 21, pierdes automáticamente.");
                Console.WriteLine("10. Si tú y el crupier tenéis la misma puntuación, es un empate.\n");
            }
        }
    }
}
