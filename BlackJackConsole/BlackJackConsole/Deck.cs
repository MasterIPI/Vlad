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
            for (int i = 0; i < Enum.GetNames(typeof(Suits)).Length; i++)
            {
                int card = (int)CardNames.Two;
                int cardValue = card;

                for (int j = 0; j < Enum.GetNames(typeof(CardNames)).Length; j++, card++)
                {
                    if (card <= (int)CardNames.Ten)
                    {
                        _deck.Add(new Card((CardNames)card, (Suits)i, cardValue));
                    }

                    if (card > (int)CardNames.Ten)
                    {
                        for (; j < Enum.GetNames(typeof(CardNames)).Length; j++, card++)
                        {
                            if (card == (int)CardNames.A)
                            {
                                cardValue++;
                                _deck.Add(new Card((CardNames)card, (Suits)i, cardValue));
                                break;
                            }

                            _deck.Add(new Card((CardNames)card, (Suits)i, cardValue));
                        }
                    }

                    if (cardValue <= (int)CardNames.Nine)
                    {
                        cardValue++;
                    }
                }
            }
        }

        public Deck()
        {
            _deck = new List<Card>();
            CreateDeck();
        }
    }
}
