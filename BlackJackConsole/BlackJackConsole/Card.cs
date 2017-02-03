using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    public struct Card
    {
        public CardNames Name { get; set; }
        public Suits Suit { get; set; }
        public int Value { get; set; }

        public Card(CardNames name, Suits suit, int val)
        {
            Name = name;
            Suit = suit;
            Value = val;
        }
    }

}
