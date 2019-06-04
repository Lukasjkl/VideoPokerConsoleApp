using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{
    // View class to hold all display methods
    class View
    {
        // Method to display cards on the console
        public static void DealCards(Card[] deckArray)
        {
            Console.WriteLine("New deck: ");
            Console.Write("ID: ");
            for (int i = 1; i <= 5; i++) Console.Write("{0, -20}", i);

            Console.WriteLine();

            for (int i = 0; i < deckArray.Length; i++)
            {
                Console.Write("{0, -20}", deckArray[i]);
            }
            Console.WriteLine();
        }

        // Method to display old hand and winning on the console
        public static void DisplayWinning(HAND hand, Card[] oldDeck)
        {
            Console.Clear();
            Console.WriteLine("Your hand was: ");
            for (int i = 0; i < oldDeck.Length; i++)
            {
                Console.Write("{0, -20}", oldDeck[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Result: " + DetermineWinner.HandCombo(hand) + " and "
                + DetermineWinner.Winning(hand) + " was added to your credit.");
        }

        // Method to display in-game actions
        public static void DisplayPlayActions()
        {
            Console.WriteLine("Possible actions - QUIT/DISCARD/DRAW/CREDIT/PRIZES");
            Console.Write("Choose action: ");
        }

        // Method to display Discard actions
        public static void DisplayDiscardActions()
        {
            Console.WriteLine("Possible actions - QUIT/DRAW");
            Console.Write("Choose action: ");
        }

        // Method to display credit
        public static void DisplayCredit(Player curPlayer)
        {
            Console.WriteLine("Your credit is: " + curPlayer.Credit);
        }

        // Method to display text about discard IDs
        public static void DisplayDiscardIDS()
        {
            Console.WriteLine("Choose card IDs to be discarded (separate by whitespace or any symbol): ");
        }

        // Method to display possible prizes
        public static void DisplayPrizes()
        {
            Console.WriteLine("--------PRIZES--------");
            foreach (HAND hand in Enum.GetValues(typeof(HAND)))
            {
                Console.WriteLine("{0, -20}", DetermineWinner.HandCombo(hand) + " - " + DetermineWinner.Winning(hand));
            }
            Console.WriteLine("----------------------");
        }

        // Method to display start actions
        public static void DisplayStartActions()
        {
            Console.WriteLine("Possible actions - QUIT/DEAL");
            Console.Write("Choose action: ");
        }
    }
}
