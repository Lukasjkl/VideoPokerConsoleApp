using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{
    class Card
    {
        // Enum properties
        public SUIT SuitValue { get; set; }
        public VALUE CardValue { get; set; }

        // Card text is displayed on the screen after DealCard() method is called
        public override string ToString()
        {
            return CardValue + " " + SuitValue;
        }
    }
}
