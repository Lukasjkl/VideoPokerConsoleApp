using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{
    // Gameplay is a repetition of same steps, thus, Template design pattern is used to make it more efficient
    class Gameplay : Template
    {
        private Deck gameDeck; // Instance of Deck object
        private Player currentPlayer; // Instance of current player
        private string playerChoice = ""; // String to keep track of player choices

        private const int NUMBER_OF_CARDS = 5; // 5 is chosen as a number because there are only 5 cards on the table at the time
        private Card[] deckArray; // local deck array

        private List<int> cardsDiscarded; // List of Integers that will hold IDs of discarded cards on the table

        // Constructor method
        public Gameplay()
        {
            gameDeck = new Deck();
            currentPlayer = new Player();
            deckArray = new Card[NUMBER_OF_CARDS];
            cardsDiscarded = new List<int>();
        }

        // Start method of Template pattern
        protected override void DoStart()
        {
            FillLocalDeck();
            
            // Gives start choices to player
            Console.WriteLine("Possible actions - QUIT/DEAL");
            // While loop that does not let to proceed further when invalid action is chosen by user
            while (!IsInputValid(playerChoice))
            {
                Console.Write("Choose action: ");
                playerChoice = Console.ReadLine();
            }
            DealCards();
        }

        // End method of Template pattern
        protected override bool IsEnd()
        {
            if (playerChoice == "QUIT") return true;
            else return false;
        }

        // Play game method of Template pattern
        protected override void PlayGame()
        {
            Console.WriteLine("Possible actions - QUIT/DISCARD/DRAW/CREDIT");
            Console.Write("Choose action: ");
            HandleChoice(playerChoice = Console.ReadLine());
        }

        // End method of Template pattern
        protected override void DoEnd()
        {
            Environment.Exit(0);
        }

        // Method to check whether start input is valid
        private bool IsInputValid(string choice)
        {
            if (choice != "DEAL" && choice != "QUIT") return false;
            else return true;
        }

        private void FillLocalDeck()
        {
            // Fills local deck array with cards from a deck with 52 shuffled cards
            for (int i = 0; i < NUMBER_OF_CARDS; i++)
            {
                deckArray[i] = gameDeck.DealCard();
            }
        }

        // Method to reset decks for a new game
        private void ResetLocalDeck()
        {
            gameDeck = new Deck();
            deckArray = new Card[NUMBER_OF_CARDS];
            cardsDiscarded = new List<int>();
            FillLocalDeck();
        }
        
        // Method to display cards on the console
        private void DealCards()
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
        private void DisplayWinning(HAND hand, Card[] oldDeck)
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

        // Method that handles HOLD choice
        private void HandleHold()
        {
            Console.WriteLine("Choose card IDs to be discarded (separate by whitespace or any symbol): ");
            String text = Console.ReadLine();
            // Gets only numbers from input string
            Regex regex = new Regex(@"\D+|(^\|\*\s*)|(\s*\|\s*)");
            text = regex.Replace(text, "|");
            String[] splitString = text.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            int arrayLength = 0;
            // if statement to ignore more numbers than 5 (because only 5 cards are displayed at the time)
            if (splitString.Length > 5) arrayLength = 5; 
            else arrayLength = splitString.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                if (int.Parse(splitString[i]) <= 5) cardsDiscarded.Add(int.Parse(splitString[i]));
            }
            deckArray = gameDeck.SwapDiscardedCards(deckArray, cardsDiscarded);
            DealCards();
            // While loop does not let to discard cards again (forces to draw with discarded ones)
            while (playerChoice != "QUIT" && playerChoice != "DRAW")
            {
                Console.WriteLine("Possible actions - QUIT/DRAW");
                Console.Write("Choose action: ");
                playerChoice = Console.ReadLine();
            }
            HandleChoice(playerChoice);
        }   

        // Method to handle DRAW choice
        private void HandleDraw()
        {
            EvaluateHand evaluator = new EvaluateHand(deckArray);
            HAND hand = evaluator.HandEvaluator(); // gets value of hand displayed
            currentPlayer.AddCredit(DetermineWinner.Winning(hand)); // Adds credit to player's balance
            DisplayWinning(hand, deckArray);
            ResetLocalDeck();
            DealCards();
        }
        
        // Method to handle choices
        private void HandleChoice(string userChoice)
        {
            switch(userChoice)
            {
                case "CREDIT":
                    Console.WriteLine("Your credit is: " + currentPlayer.Credit);
                    break;

                case "DRAW":
                    HandleDraw();
                    break;

                    // According to chosen IDs, cards will be discarded and the ones that are not chosen to be discarded
                    // will stay on the table
                case "DISCARD":
                    HandleHold();
                    break;
            }
        }
    }
}
