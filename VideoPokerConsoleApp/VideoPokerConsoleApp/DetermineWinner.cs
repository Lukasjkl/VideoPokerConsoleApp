using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{
    class DetermineWinner
    {
        // Method to return prize 
        public static int Winning(HAND hand)
        {
            switch(hand)
            {
                case HAND.JacksOrBetter: return 1;
                case HAND.TwoPair: return 2;
                case HAND.ThreeOfAKind: return 3;
                case HAND.Straight: return 4;
                case HAND.Flush: return 6;
                case HAND.FullHouse: return 9;
                case HAND.FourOfAKind: return 25;
                case HAND.StraightFlush: return 50;
                case HAND.RoyalFlush: return 800;
                default: return 0;
            }
        }

        // Method to return hand 
        public static string HandCombo(HAND hand)
        {
            switch (hand)
            {
                case HAND.JacksOrBetter: return "Jacks Or Better";
                case HAND.TwoPair: return "Two Pair";
                case HAND.ThreeOfAKind: return "Three Of A Kind";
                case HAND.Straight: return "Straight";
                case HAND.Flush: return "Flush";
                case HAND.FullHouse: return "Full House";
                case HAND.FourOfAKind: return "Four Of A Kind";
                case HAND.StraightFlush: return "Straight Flush";
                case HAND.RoyalFlush: return "Royal Flush";
                default: return "All others";
            }
        }
    }
}
