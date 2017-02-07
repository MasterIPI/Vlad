using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackJackConsole.ConsoleWorks;

namespace BlackJackConsole
{
    public class Game
    {
        private Deck _deck;
        private List<Player> _players;

        private const int blackJackValue = 21;
        private const int maxDealersHandValue = 17;


        public Game()
        {
            _deck = new Deck();
            _deck.Shuffle();
        }

        public static int GetHandValue(Player player)
        {
            int sum = 0;
            foreach (Card card in player.Hand)
            {
                sum += card.Value;
            }

            foreach (Card card in player.Hand)
            {
                if (card.Name == CardName.A && sum > blackJackValue)
                {
                    sum -= 10;
                }
            }

            return sum;
        }

        public void PlayGame(int playerNum)
        {
            string answer = string.Empty;

            _players = new List<Player>(playerNum);

            GetHumanPlayersNames(_players);
            GetHumanPlayersBetsAndHands(_players, _deck);

            ShowAllCards(_players);
            PlayHand(_players);
            GetWinner(_players);
        }

        public void GetWinner(List<Player> players)
        {
            ShowAllCards(players);

            List<int> HandValues = new List<int>(players.Count);

            for (int i = 0; i < players.Count; i++)
            {
                HandValues.Add(GetHandValue(players[i]));
            }

            for (int i = 1; i < HandValues.Count; i++)
            {
                if (HandValues[i] > blackJackValue)
                {
                    Player current = players[i];
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.Loose);
                }

                if (HandValues[i] == blackJackValue)
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.BlackJack);
                }

                if (HandValues[i] == HandValues[0] && HandValues[i] < blackJackValue && HandValues[0] < blackJackValue)
                {
                    Player current = players[i];
                    current.Balance += current.Bet;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.Draw);
                }

                if ((HandValues[i] > HandValues[0]) && (HandValues[i] < blackJackValue) && (HandValues[0] < blackJackValue))
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.Win);
                }

                if ((HandValues[i] < HandValues[0]) && (HandValues[0] > blackJackValue) && (HandValues[i] < blackJackValue))
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.Win);
                }
            }

            ShowAllPlayers(players);
            WaitForExit();
        }

        

        public void PlayHand(List<Player> players)
        {
            string answer = string.Empty;
            int playersHandValue = 0;

            foreach (Player player in players)
            {
                playersHandValue = GetHandValue(player);

                if (player.Name != "Dealer")
                {
                    while (playersHandValue < blackJackValue)
                    {
                        ShowAllCards(players);

                        answer = AskPlayerPickCard(player);

                        if (answer == "y")
                        {
                            player.Hand.AddRange(_deck.PopCards(1));
                            ShowPlayersHand(player);
                            playersHandValue = GetHandValue(player);
                        }

                        if (answer == "n")
                        {
                            break;
                        }
                    }
                }

                else
                {
                    while (playersHandValue < blackJackValue && playersHandValue < maxDealersHandValue)
                    {
                        player.Hand.AddRange(_deck.PopCards(1));
                        playersHandValue = GetHandValue(player);
                    }
                }

            }
        }
    }
}
