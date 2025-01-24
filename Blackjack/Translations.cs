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
            }
            else if (language == "es")
            {
                // Spanish translations
                _translations.Add("welcome", "¡Bienvenidos a Blackjack!");
                _translations.Add("startingBalance", "Tu saldo inicial es: ");
                _translations.Add("reshuffle", "El mazo tiene pocas cartas. Barajando...");
                _translations.Add("placeBet", "Por favor, coloca tu apuesta (tu saldo actual es {0}): ");
                _translations.Add("invalidBet", "Apuesta inválida. Por favor, ingresa una cantidad válida.");
                _translations.Add("playerChoiceFirst", "¿Quieres [t]omar una carta, [s]tacar, o [d]oblar?");
                _translations.Add("playerChoice", "¿Quieres [t]omar una carta o [s]tacar?");
                _translations.Add("invalidChoice", "Opción inválida. Por favor selecciona [t]omar carta, [s]tacar, o [d]oblar.");
                _translations.Add("noDoubleBalance", "No tienes suficiente saldo para doblar.");
                _translations.Add("doubleDown", "Elegiste doblar. Tu nuevo total es: {0}");
                _translations.Add("dealtCard", "Te dieron una {0}. Tu nuevo total es: {1}");
                _translations.Add("busted", "¡Te has pasado!");
                _translations.Add("tieBlackjack", "¡Es un empate! Tanto tú como el dealer tienen Blackjack.");
                _translations.Add("playerBlackjack", "¡Tienes un Blackjack!");
                _translations.Add("gameStats", "Victorias: {0}, Derrotas: {1}, Saldo: {2}");
                _translations.Add("outOfMoney", "Te quedaste sin dinero. Fin del juego.");
                _translations.Add("playAgain", "¿Quieres jugar de nuevo? (s/n)");
                _translations.Add("dealerWin", "¡El croupier gana!");
                _translations.Add("playerWin", "¡Ganaste!");
                _translations.Add("tie", "¡Es un empate!");
                _translations.Add("pressKey", "Presiona cualquier tecla para continuar...");
                _translations.Add("playerHand", "Mano del jugador:");
                _translations.Add("totalScore", "Puntaje total");
                _translations.Add("dealerShows", "El croupier muestra");
                _translations.Add("dealerHand", "Mano del dealer:");
                _translations.Add("card", "Carta");
            }
            else
            {
                // Default to English if language code is not recognized
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
