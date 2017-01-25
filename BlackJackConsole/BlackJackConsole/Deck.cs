using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    class Deck
    {
        private Card[] _deck;

        public void Shuffle()
        {
            Random r = new Random();
            _deck = _deck.OrderBy(x => r.NextDouble()).ToArray();
        }

        public override string ToString()
        {
            string tmp = string.Empty;

            foreach (Card card in _deck)
            {
                tmp += card.ToString() + "\n";
            }
            return tmp;
        }

        public Card[] PopCards(int count)
        {
            Card[] tmp = _deck.Take(count).ToArray();
            _deck = _deck.Except(tmp).ToArray();

            return tmp;
        }

        public void CreateDeck()
        {
            int card = 2;
            int suit = 0;

            for (int i = 0; i < _deck.Length; i++)
            {
                if (card <= 10)
                {
                    _deck[i] = new Card(card.ToString(), GetSuit(suit), card);
                    card++;
                }

                else if (card > 10)
                {
                    switch (card)
                    {
                        case 11:
                            _deck[i] = new Card("J", GetSuit(suit), 10);
                            card++;
                            break;

                        case 12:
                            _deck[i] = new Card("Q", GetSuit(suit), 10);
                            card++;
                            break;

                        case 13:
                            _deck[i] = new Card("K", GetSuit(suit), 10);
                            card++;
                            break;

                        case 14:
                            _deck[i] = new Card("A", GetSuit(suit), 11);
                            card = 2;
                            suit++;
                            break;
                    }
                }
            }
        }

        private char GetSuit(int suit)
        {
            char _suit = ' ';

            switch (suit)
            {
                case (int)Suits.Clubs:
                    _suit = '\u2663';
                    break;

                case (int)Suits.Diamonds:
                    _suit = '\u2666';
                    break;

                case (int)Suits.Hearts:
                    _suit = '\u2665';
                    break;

                case (int)Suits.Spades:
                    _suit = '\u2660';
                    break;
            }

            return _suit;
        }

        public Deck()
        {
            _deck = new Card[52]; //Deck capacity
            CreateDeck();
        }
    }
}
