using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    struct Player
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
                if ((int)card.Name <= (int)CardNames.Ten)
                {
                    sum += (int)card.Name;
                }

                if ((int)card.Name > (int)CardNames.Ten)
                {
                    sum += (int)CardNames.Ten;
                }

                if (card.Name == CardNames.A)
                {
                    sum += 11;
                }
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
