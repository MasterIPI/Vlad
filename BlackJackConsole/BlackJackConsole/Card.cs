using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    struct Card
    {
        public CardNames Name { get; set; }
        public Suits Suit { get; set; }

        public Card(int name, int suit, int val)
        {
            Name = (CardNames)name;
            Suit = (Suits)suit;
        }
    }

}
