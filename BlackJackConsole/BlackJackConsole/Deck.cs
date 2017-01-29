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

        public Card[] PopCards(int count)
        {
            Card[] tmp = _deck.Take(count).ToArray();
            _deck = _deck.Except(tmp).ToArray();

            return tmp;
        }

        public void CreateDeck()
        {
            int card = (int)CardNames.Two;
            int suit = (int)Suits.Spades;

            for (int i = 0; i < _deck.Length; i++)
            {
                if (card <= (int)CardNames.Ten)
                {
                    _deck[i] = new Card(card, suit, card);
                }

                if (card > (int)CardNames.Ten)
                {
                    _deck[i] = new Card(card, suit, (int)CardNames.Ten);
                }

                if (card == (int)CardNames.A)
                {
                    _deck[i] = new Card(card, suit, (int)CardNames.J);
                    card = 2;
                    suit++;
                    continue;
                }

                card++;
            }
        }

        public Deck()
        {
            _deck = new Card[Enum.GetNames(typeof(Suits)).Length * Enum.GetNames(typeof(CardNames)).Length];
            CreateDeck();
        }
    }
}
