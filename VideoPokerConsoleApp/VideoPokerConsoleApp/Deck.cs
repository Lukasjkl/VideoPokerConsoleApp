using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{
    class Deck
    {
        private const int NUMBER_OF_CARDS = 52; // Number of cards in the deck (13 possible values * 4 possible suits = 52)
        private int curCardIndex = 0; // Index of current card displayed
        private readonly Card[] deckArray; // Array to hold cards in a deck

        // Constructor method to initialize deck array
        public Deck()
        {
            deckArray = new Card[NUMBER_OF_CARDS];
            FillDeck();
            ShuffleDeck();
        }

        // Method to fill array with cards
        private void FillDeck()
        {
            int arrayIndex = 0;
            foreach(SUIT suit in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE value in Enum.GetValues(typeof(VALUE)))
                {
                    deckArray[arrayIndex] = new Card { CardValue = value, SuitValue = suit };
                    arrayIndex++;
                }
            }
        }

        // Method to shuffle cards in the cards' array
        private void ShuffleDeck()
        {
            Card tempCard = null;
            Random rand = new Random();

            //Shuffles cards 10 times
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < NUMBER_OF_CARDS; i++)
                {
                    int randIndex = rand.Next(NUMBER_OF_CARDS);
                    tempCard = deckArray[i];
                    deckArray[i] = deckArray[randIndex];
                    deckArray[randIndex] = tempCard;
                }
            }
        }

        // Returns a card from the deck to set up game deck of 5 cards
        public Card DealCard()
        {
            if (curCardIndex > deckArray.Length)
            {
                return null;
            }
            else return deckArray[curCardIndex++];
        }

        // Method to swap discarded cards with new random ones
        public Card[] SwapDiscardedCards(Card[] deckArray, List<int> cardsDiscarded)
        {
            foreach (int value in cardsDiscarded)
            {
                deckArray[value - 1] = DealCard();
            }

            return deckArray;
        }
    }
}
