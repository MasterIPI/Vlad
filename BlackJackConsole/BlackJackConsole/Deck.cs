using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    public class Deck
    {
        private List<Card> _deck;

        public void Shuffle()
        {
            Random r = new Random();
            _deck = _deck.OrderBy(x => r.NextDouble()).ToList();
        }

        public Card[] PopCards(int count)
        {
            Card[] tmp = _deck.Take(count).ToArray();
            _deck = _deck.Except(tmp).ToList();

            return tmp;
        }

        public void CreateDeck()
        {
            int card = (int)CardNames.Two;
            int suit = (int)Suits.Spades;
            int value = card;

            for (int i = 0; i < _deck.Capacity; i++)
            {
                if (card <= (int)CardNames.Ten)
                {
                    _deck.Add(new Card((CardNames)card, (Suits)suit, value));
                }

                if (card > (int)CardNames.Ten)
                {
                    _deck.Add(new Card((CardNames)card, (Suits)suit, value));
                }

                if (card == (int)CardNames.A)
                {
                    _deck.Add(new Card((CardNames)card, (Suits)suit, value));
                    card = (int)CardNames.Two;
                    suit++;
                    value = card;
                    continue;
                }

                card++;
                value++;
            }
        }

        public Deck()
        {
            int deckCapacity = Enum.GetNames(typeof(Suits)).Length * Enum.GetNames(typeof(CardNames)).Length;
            _deck = new List<Card>(deckCapacity);
            CreateDeck();
        }
    }
}
