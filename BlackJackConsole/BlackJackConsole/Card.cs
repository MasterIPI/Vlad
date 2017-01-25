using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    struct Card
    {
        private string _name;
        private char _suit;
        private int _value;

        public Card(string name, char suit, int val)
        {
            _name = name;
            _suit = suit;
            _value = val;
        }

        public int Value
        {
            get { return _value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public void ShowCard()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return string.Format($"{_name}{_suit}");
        }
    }
    enum Suits { Spades, Clubs, Hearts, Diamonds};
}
