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

        public List<Card> PopCards(int count)
        {
            List<Card> tmp = _deck.Take(count).ToList();
            _deck = _deck.Except(tmp).ToList();

            return tmp;
        }

        public void CreateDeck()
        {
            Card tmpcard = new Card();

            for (int suit = 0; suit < Enum.GetNames(typeof(CardSuit)).Length; suit++)
            {
                int cardValue = 2;

                for (int cardName = 0; cardName < Enum.GetNames(typeof(CardName)).Length; cardName++)
                {
                    if (cardName <= (int)CardName.Ten)
                    {
                        tmpcard.Name = (CardName)cardName;
                        tmpcard.Suit = (CardSuit)suit;
                        tmpcard.Value = cardValue;

                        _deck.Add(tmpcard);
                    }

                    if (cardName > (int)CardName.Ten)
                    {
                        for (; cardName < Enum.GetNames(typeof(CardName)).Length; cardName++)
                        {
                            tmpcard.Name = (CardName)cardName;
                            tmpcard.Suit = (CardSuit)suit;


                            if (cardName == (int)CardName.A)
                            {
                                cardValue++;
                                tmpcard.Value = cardValue;
                                _deck.Add(tmpcard);
                                break;
                            }

                            tmpcard.Value = cardValue;
                            _deck.Add(tmpcard);
                        }
                    }

                    if (cardName <= (int)CardName.Nine)
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
