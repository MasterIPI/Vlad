using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    struct Player
    {
        private int _balance;
        private int _bet;
        private string _name;
        private List<Card> _hand;

        public List<Card> GetHand
        {
            get { return _hand; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public int Bet
        {
            get { return _bet; }
            set { _bet = value; }
        }

        public void ShowHand()
        {
            if (_name != "Dealer")
            {
                Console.WriteLine($"Player {_name}, balance = {_balance}:");
                foreach (Card card in _hand)
                {
                    card.ShowCard();
                }
                Console.WriteLine($"Hand value: {GetHandValue()}");
                Console.WriteLine($"Your bet is {_bet}");
                Console.WriteLine(new string('=', 10));
            }

            else
            {
                Console.WriteLine($"{_name}:");
                foreach (Card card in _hand)
                {
                    card.ShowCard();
                }
                Console.WriteLine($"Hand value: {GetHandValue()}");
                Console.WriteLine(new string('=', 10));
            }
        }

        public int GetHandValue()
        {
            int sum = 0;
            foreach (Card card in _hand)
            {
                sum += card.Value;
            }

            foreach (Card card in _hand)
            {
                if (card.Name == "A" && sum > 21)
                {
                    sum -= 10;
                }
            }
            
            return sum;
        }

        public void ShowPlayer()
        {
            Console.WriteLine($"Player {_name}, balance {_balance}:");
        }

        public Player(string name)
        {
            _name = name;
            _balance = 100;
            _bet = 0;
            _hand = new List<Card>();
        }
    }
}
