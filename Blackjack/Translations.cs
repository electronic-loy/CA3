using System;
using System.Collections.Generic;

namespace Blackjack
{
    public class Translations
    {
        private readonly Dictionary<string, string> _translations;

        //This was all made by Chat GPT indeed

        // Constructor to initialize the translation dictionary based on the selected language
        public Translations(string language)
        {
            _translations = new Dictionary<string, string>();

            // Load the translations based on the selected language
            if (language == "en")
            {
                // English translations
                _translations.Add("welcome", "Welcome to Blackjack!");
                _translations.Add("startingBalance", "Your starting balance is: {0} ");
                _translations.Add("reshuffle", "The deck is low on cards. Reshuffling...");
                _translations.Add("placeBet", "Please place your bet (your current balance is {0}): ");
                _translations.Add("invalidBet", "Invalid bet. Please enter a valid amount.");
                _translations.Add("playerChoiceFirst", "Would you like to [t]ake a card, [s]tand, or [d]ouble down?");
                _translations.Add("playerChoice", "Would you like to [t]ake a card or [s]tand?");
                _translations.Add("invalidChoice", "Invalid choice. Please select [t]ake card, [s]tand, or [d]ouble down.");
                _translations.Add("noDoubleBalance", "You don't have enough balance for doubling down.");
                _translations.Add("doubleDown", "You chose to double down. Your new total is: {0}");
                _translations.Add("dealtCard", "You were dealt a {0}. Your new total is: {1}");
                _translations.Add("busted", "You busted!");
                _translations.Add("dealerBusted", "The dealer busted!");
                _translations.Add("tieBlackjack", "It's a tie! Both you and the dealer have Blackjack.");
                _translations.Add("playerBlackjack", "You got a Blackjack!");
                _translations.Add("gameStats", "Wins: {0}, Losses: {1}, Balance: {2}");
                _translations.Add("outOfMoney", "You ran out of money. Game over.");
                _translations.Add("playAgain", "Do you want to play again? (y/n)");
                _translations.Add("dealerWin", "The dealer wins!");
                _translations.Add("playerWin", "You win!");
                _translations.Add("tie", "It's a tie!");
                _translations.Add("pressKey", "Press any key to continue...");
                _translations.Add("playerHand", "Player's Hand:");
                _translations.Add("totalScore", "Total Score");
                _translations.Add("dealerShows", "Dealer shows");
                _translations.Add("dealerHand", "Dealer's Hand:");
                _translations.Add("card", "Card");

                // Card translations
                _translations.Add("Ace", "Ace");
                _translations.Add("Two", "Two");
                _translations.Add("Three", "Three");
                _translations.Add("Four", "Four");
                _translations.Add("Five", "Five");
                _translations.Add("Six", "Six");
                _translations.Add("Seven", "Seven");
                _translations.Add("Eight", "Eight");
                _translations.Add("Nine", "Nine");
                _translations.Add("Ten", "Ten");
                _translations.Add("Jack", "Jack");
                _translations.Add("Queen", "Queen");
                _translations.Add("King", "King");
                _translations.Add("Hearts", "of Hearts");
                _translations.Add("Diamonds", "of Diamonds");
                _translations.Add("Clubs", "of Clubs");
                _translations.Add("Spades", "of Spades");
            }
            else if (language == "es")
            {
                // Spanish translations
                _translations.Add("welcome", "¡Bienvenidos a Blackjack!");
                _translations.Add("startingBalance", "Tu saldo inicial es: ");
                _translations.Add("reshuffle", "El mazo tiene pocas cartas. Barajando...");
                _translations.Add("placeBet", "Por favor, coloca tu apuesta (tu saldo actual es {0}): ");
                _translations.Add("invalidBet", "Apuesta inválida. Por favor, ingresa una cantidad válida.");
                _translations.Add("playerChoiceFirst", "¿Quieres [t]omar una carta, [s]altar al turno del crupier, o [d]oblar?");
                _translations.Add("playerChoice", "¿Quieres [t]omar una carta o [s]altar al turno del crupier?");
                _translations.Add("invalidChoice", "Opción inválida. Por favor selecciona [t]omar carta, [s]tacar, o [d]oblar.");
                _translations.Add("noDoubleBalance", "No tienes suficiente saldo para doblar.");
                _translations.Add("doubleDown", "Elegiste doblar. Tu nuevo total es: {0}");
                _translations.Add("dealtCard", "Te dieron una {0}. Tu nuevo total es: {1}");
                _translations.Add("busted", "¡Te has pasado!");
                _translations.Add("tieBlackjack", "¡Es un empate! Tanto tú como el crupier tenéis Blackjack.");
                _translations.Add("playerBlackjack", "¡Tienes un Blackjack!");
                _translations.Add("gameStats", "Victorias: {0}, Derrotas: {1}, Saldo: {2}");
                _translations.Add("outOfMoney", "Te quedaste sin dinero. Fin del juego, colegui.");
                _translations.Add("playAgain", "¿Quieres jugar de nuevo? (s/n)");
                _translations.Add("dealerBusted", "El crupier se ha pasado.");
                _translations.Add("dealerWin", "¡El crupier gana!");
                _translations.Add("playerWin", "¡Ganaste!");
                _translations.Add("tie", "¡Es un empate!");
                _translations.Add("pressKey", "Presiona cualquier tecla para continuar...");
                _translations.Add("playerHand", "Mano del jugador:");
                _translations.Add("totalScore", "Puntuación total");
                _translations.Add("dealerShows", "El crupier muestra");
                _translations.Add("dealerHand", "Mano del crupier:");
                _translations.Add("card", "Carta");

                // Card translations
                _translations.Add("Ace", "As");
                _translations.Add("Two", "Dos");
                _translations.Add("Three", "Tres");
                _translations.Add("Four", "Cuatro");
                _translations.Add("Five", "Cinco");
                _translations.Add("Six", "Seis");
                _translations.Add("Seven", "Siete");
                _translations.Add("Eight", "Ocho");
                _translations.Add("Nine", "Nueve");
                _translations.Add("Ten", "Diez");
                _translations.Add("Jack", "Jota");
                _translations.Add("Queen", "Reina");
                _translations.Add("King", "Rey");
                _translations.Add("Hearts", "de Corazones");
                _translations.Add("Diamonds", "de Diamantes");
                _translations.Add("Clubs", "de Tréboles");
                _translations.Add("Spades", "de Picas");
            }
            else if (language == "pt-PT")
            {
                // Portuguese (Portugal) translations
                _translations.Add("welcome", "Bem-vindo ao Blackjack!");
                _translations.Add("startingBalance", "O seu saldo inicial é: ");
                _translations.Add("reshuffle", "O baralho está quase sem cartas. A embaralhar...");
                _translations.Add("placeBet", "Por favor, faça a sua aposta (o seu saldo atual é {0}): ");
                _translations.Add("invalidBet", "Aposta inválida. Por favor, introduza um valor válido.");
                _translations.Add("playerChoiceFirst", "Deseja [t]irar uma carta, [s]altar a vez ou [d]uplicar a aposta?");
                _translations.Add("playerChoice", "Deseja [t]irar uma carta ou [s]altar a vez?");
                _translations.Add("invalidChoice", "Opção inválida. Por favor, selecione [t]irar carta, [s]altar a vez ou [d]uplicar a aposta.");
                _translations.Add("noDoubleBalance", "Não tem saldo suficiente para duplicar a aposta.");
                _translations.Add("doubleDown", "Duplicou a aposta. O seu novo total é: {0}");
                _translations.Add("dealtCard", "Tirou uma {0}. O seu novo total é: {1}");
                _translations.Add("busted", "Ultrapassou 21!");
                _translations.Add("tieBlackjack", "Empate! Tanto o jogador como o dealer têm Blackjack.");
                _translations.Add("playerBlackjack", "Tem Blackjack!");
                _translations.Add("gameStats", "Vitórias: {0}, Derrotas: {1}, Saldo: {2}");
                _translations.Add("outOfMoney", "Ficou sem dinheiro. Fim de jogo.");
                _translations.Add("playAgain", "Deseja jogar novamente? (s/n)");
                _translations.Add("dealerBusted", "O croupier foi longe demais");
                _translations.Add("dealerWin", "O dealer venceu!");
                _translations.Add("playerWin", "Ganhou!");
                _translations.Add("tie", "Empate!");
                _translations.Add("pressKey", "Prima qualquer tecla para continuar...");
                _translations.Add("playerHand", "Mão do Jogador:");
                _translations.Add("totalScore", "Total");
                _translations.Add("dealerShows", "O dealer mostra");
                _translations.Add("dealerHand", "Mão do Dealer:");
                _translations.Add("card", "Carta");

                // Card translations

                _translations.Add("Ace", "Ás");
                _translations.Add("Two", "Dois");
                _translations.Add("Three", "Três");
                _translations.Add("Four", "Quatro");
                _translations.Add("Five", "Cinco");
                _translations.Add("Six", "Seis");
                _translations.Add("Seven", "Sete");
                _translations.Add("Eight", "Oito");
                _translations.Add("Nine", "Nove");
                _translations.Add("Ten", "Dez");
                _translations.Add("Jack", "Valete");
                _translations.Add("Queen", "Rainha");
                _translations.Add("King", "Rei");
                _translations.Add("Hearts", "de Copas");
                _translations.Add("Diamonds", "de Ouros");
                _translations.Add("Clubs", "de Paus");
                _translations.Add("Spades", "de Espadas");
            }
            else // English default
            {
                _translations.Add("welcome", "Welcome to Blackjack!");
                _translations.Add("startingBalance", "Your starting balance is: ");
                _translations.Add("reshuffle", "The deck is low on cards. Reshuffling...");
                _translations.Add("placeBet", "Please place your bet (your current balance is {0}): ");
                _translations.Add("invalidBet", "Invalid bet. Please enter a valid amount.");
                _translations.Add("playerChoiceFirst", "Would you like to [t]ake a card, [s]tand, or [d]ouble down?");
                _translations.Add("playerChoice", "Would you like to [t]ake a card or [s]tand?");
                _translations.Add("invalidChoice", "Invalid choice. Please select [t]ake card, [s]tand, or [d]ouble down.");
                _translations.Add("noDoubleBalance", "You don't have enough balance for doubling down.");
                _translations.Add("doubleDown", "You chose to double down. Your new total is: {0}");
                _translations.Add("dealtCard", "You were dealt a {0}. Your new total is: {1}");
                _translations.Add("busted", "You busted!");
                _translations.Add("tieBlackjack", "It's a tie! Both you and the dealer have Blackjack.");
                _translations.Add("playerBlackjack", "You got a Blackjack!");
                _translations.Add("gameStats", "Wins: {0}, Losses: {1}, Balance: {2}");
                _translations.Add("outOfMoney", "You ran out of money. Game over.");
                _translations.Add("playAgain", "Do you want to play again? (y/n)");
                _translations.Add("dealerWin", "The dealer wins!");
                _translations.Add("playerWin", "You win!");
                _translations.Add("tie", "It's a tie!");
                _translations.Add("pressKey", "Press any key to continue...");
                _translations.Add("playerHand", "Player's Hand:");
                _translations.Add("totalScore", "Total Score");
                _translations.Add("dealerShows", "Dealer shows");
                _translations.Add("dealerHand", "Dealer's Hand:");
                _translations.Add("card", "Card");

                // Card translations
                _translations.Add("Ace", "Ace");
                _translations.Add("Two", "Two");
                _translations.Add("Three", "Three");
                _translations.Add("Four", "Four");
                _translations.Add("Five", "Five");
                _translations.Add("Six", "Six");
                _translations.Add("Seven", "Seven");
                _translations.Add("Eight", "Eight");
                _translations.Add("Nine", "Nine");
                _translations.Add("Ten", "Ten");
                _translations.Add("Jack", "Jack");
                _translations.Add("Queen", "Queen");
                _translations.Add("King", "King");
                _translations.Add("Hearts", "Hearts");
                _translations.Add("Diamonds", "Diamonds");
                _translations.Add("Clubs", "Clubs");
                _translations.Add("Spades", "Spades");
            }

        }


        // Method to get the translation for a given key
        public string Get(string key)
        {
            if (_translations.ContainsKey(key))
            {
                return _translations[key];
            }
            else
            {
                return key; // If translation is missing, return the key as a fallback
            }
        }
    }
}
