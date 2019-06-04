using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{
    // Player object to keep player's credit
    class Player
    {
        private int credit;
        
        // Constructor method
        // Each time game is started, credit is set to 0
        public Player()
        {
            credit = 0;
        }

        public int Credit { get => credit; set => credit = value; }

        // Method to add credit to balance
        public void AddCredit(int amountToAdd)
        {
            credit += amountToAdd;
        }
    }
}
