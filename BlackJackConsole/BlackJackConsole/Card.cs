using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    public struct Card
    {
        public CardName Name { get; set; }
        public CardSuit Suit { get; set; }
        public int Value { get; set; }
    }

}
