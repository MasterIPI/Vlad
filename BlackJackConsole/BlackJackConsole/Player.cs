using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    public struct Player
    {
        public int Balance { get; set; }
        public int Bet { get; set; }
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public int GetHandValue()
        {
            int sum = 0;
            foreach (Card card in Hand)
            {
                sum += card.Value;
            }

            foreach (Card card in Hand)
            {
                if (card.Name == CardNames.A && sum > 21)
                {
                    sum -= 10;
                }
            }
            
            return sum;
        }

        public Player(string name)
        {
            Name = name;
            Balance = 100;
            Bet = 0;
            Hand = new List<Card>();
        }
    }
}
