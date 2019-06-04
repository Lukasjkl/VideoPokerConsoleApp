using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{

    /*
     * Reference for this class's logic: http://www.mathcs.emory.edu/~cheung/Courses/170/Syllabus/10/pokerCheck.html
     */
    class EvaluateHand
    {
        private Card[] playerHand; // Private array to keep current player hand

        // Constructor method
        public EvaluateHand(Card[] playerHand)
        {
            this.playerHand = playerHand;
        }

        // Bool method to find Four of a kind
        private bool IsFourOfAKind()
        {
            return (playerHand.GroupBy(card => card.CardValue).Any(group => group.Count() == 4));
        }

        // Bool method to find Flush
        private bool IsFlush()
        {
            return (playerHand.GroupBy(card => card.SuitValue).Any(group => group.Count() == 5));
        }

        // Bool method to find Straight
        public bool IsStraight()
        {
            bool isStraight = false;
            Array.Sort(playerHand, (x, y) => x.CardValue.CompareTo(y.CardValue)); // Sorts playerHand array in ascending order
            for (int i = 0; i < playerHand.Length - 1; i++)
            {
                // In the sorted hand, in the case of a straight, the following card's value will always be equal
                // to the previous one when 1 is subtracted
                if ((int)playerHand[i].CardValue == (int)playerHand[i+1].CardValue - 1)
                {
                    isStraight = true;
                }
                else return isStraight = false;
            }
            return isStraight;
        }

        // Bool method to find Straight Flush
        private bool IsStraightFlush()
        {
            return (IsFlush() && IsStraight());
        }

        // Bool method to find Three of a kind
        private bool IsThreeOfAKind()
        {
            return (playerHand.GroupBy(card => card.CardValue).Any(group => group.Count() == 3));
        }

        // Bool method to find One pair
        private bool IsOnePair()
        {
            return (playerHand.GroupBy(card => card.CardValue).Count(group => group.Count() == 2) == 1);
        }

        // Bool method to find Two pair
        private bool IsTwoPair()
        {
            return (playerHand.GroupBy(card => card.CardValue).Count(group => group.Count() == 2) == 2);
        }

        // Bool method to find Full House
        private bool IsFullHouse()
        {
            return (IsOnePair() && IsThreeOfAKind());
        }

        // Bool method to find RoyalFlush
        private bool IsRoyalFlush()
        {
            // Array is sorted in IsStraight method, thus, first card has to be TEN, which has Enum value of 8
            // and last card has to be ACE, which has Enum value of 12
            // In this case it is a Royal Flush
            return (IsFlush() && IsStraight() && (int)playerHand[0].CardValue == 8 && (int)playerHand[4].CardValue == 12);
        }
        
        // Bool method to find Jacks or greater
        private bool IsJacksOrGreater()
        {
            return (IsOnePair() && !IsTwoPair() &&
                (playerHand.Count(card => (int)card.CardValue == 9) == 2) ||
                (playerHand.Count(card => (int)card.CardValue == 10) == 2) || 
                (playerHand.Count(card => (int)card.CardValue == 11) == 2) ||
                (playerHand.Count(card => (int)card.CardValue == 12) == 2));
        }

        // Method to find which hand was displayed
        public HAND HandEvaluator()
        {
            HAND tempHand = HAND.AllOther;
            if (IsJacksOrGreater()) tempHand = HAND.JacksOrBetter;
            if (IsTwoPair()) tempHand = HAND.TwoPair;
            if (IsThreeOfAKind()) tempHand = HAND.ThreeOfAKind;
            if (IsStraight()) tempHand = HAND.Straight;
            if (IsFlush()) tempHand = HAND.Flush;
            if (IsFullHouse()) tempHand = HAND.FullHouse;
            if (IsFourOfAKind()) tempHand = HAND.FourOfAKind;
            if (IsStraightFlush()) tempHand = HAND.StraightFlush;
            if (IsRoyalFlush()) tempHand = HAND.RoyalFlush;

            return tempHand;
        }
    }
}
