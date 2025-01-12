using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Deck
    {
        //Declaring cards of the deck

        public Card[] deck;
        private int currentCard;
        private const int NUMBER_OF_CARDS = 52;
        private Random ranNum;

        public Deck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            deck = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            ranNum = new Random();
            for (int count = 0; count < deck.Length; count++)
           
                deck[count] = new Card(faces[count % 13], suits[count / 13]);
                    }

        public void Shuffle()
        {
            currentCard = 0;
            for (int first = 0; first < deck.Length; first++)
            {
                int second = ranNum.Next(NUMBER_OF_CARDS);
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        public Card DealCard()
        {
            if (currentCard < deck.Length) 
                return deck[currentCard++];
            else
                return null;
        }

        ////I didn't know how to address different scores for each since 4 cards are equal scores
        ////Chat-GPT suggested simply making an array with all the explicit scores already
        ////My new problem was that Ace is also 1 point so I already thought of doing an if later

        //public static int[] Scores = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

        ////Now that we have it we do the properties and the constructor
        ////Private set for Value so that it doesn't change while playing

        //public string Suit { get; }
        //public string Rank { get; }
        //public int Score { get; }

        ////This is the simplest way I can think about doing this right now
        //public Card(string suit, string rank)
        //{
        //    Suit = suit;
        //    Rank = rank;

        //    // Find the index of the rank in the Names array
        //    int counter = Array.IndexOf(Names, rank);

        //    // Assign the score directly from the Scores array
        //    Score = Scores[counter];


        //    //Suggestion from Gemini. Many solutions
        //    //think of calculating that if ++Ace becomes 21, then it should be just 1 and not 11
        //    //I thought it's simpler to calculate depending on the current hand value and that it switches either way
        //    if (Rank == "A" && CalculateHandValue(new List<Card> { this }) > 10)
        //    {
        //        Score = 1;
        //    }
        //}
        //public override string ToString()
        //{
        //    return $"{Rank} of {Suit}";
        //}

        ////From Gemini

        //private static int CalculateHandValue(List<Card> hand)
        //{
        //    int total = 0;
        //    foreach (Card card in hand)
        //    {
        //        total += card.Score;
        //    }
        //    return total;
        //}

    }
}
