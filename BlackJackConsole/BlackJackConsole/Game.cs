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

        private const int BlackJackValue = 21;
        private const int MaxDealersHandValue = 17;


        public Game()
        {
            _deck = new Deck();
            _deck.Shuffle();
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
            Console.ReadKey();
        }

        public void GetWinner(List<Player> players)
        {
            ShowAllCards(players);

            int[] values = new int[players.Count];

            for (int i = 0; i < players.Count; i++)
            {
                values[i] = players[i].GetHandValue();
            }

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > BlackJackValue)
                {
                    Player current = players[i];
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.Loose);
                }

                if (values[i] == BlackJackValue)
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.BlackJack);
                }

                if (values[i] == values[0] && values[i] < BlackJackValue && values[0] < BlackJackValue)
                {
                    Player current = players[i];
                    current.Balance += current.Bet;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.Draw);
                }

                if ((values[i] > values[0]) && (values[i] < BlackJackValue) && (values[0] < BlackJackValue))
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.Win);
                }

                if ((values[i] < values[0]) && (values[0] > BlackJackValue) && (values[i] < BlackJackValue))
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerStatus(players[i], PlayerStatus.Win);
                }
            }

            ShowAllPlayers(players);
        }

        public void PlayHand(List<Player> players)
        {
            string answer = string.Empty;
            int playersHandValue = 0;

            foreach (Player player in players)
            {
                playersHandValue = player.GetHandValue();

                if (player.Name != "Dealer")
                {
                    while (true)
                    {
                        if (playersHandValue < BlackJackValue)
                        {
                            ShowAllCards(players);
                            Console.WriteLine($"{player.Name}, do you want to pick a card? (y/n)");
                            answer = Console.ReadLine();

                            if (answer == "y")
                            {
                                player.Hand.AddRange(_deck.PopCards(1));
                                ShowPlayersHand(player);
                                playersHandValue = player.GetHandValue();
                            }

                            if (answer == "n")
                            {
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Please, type y or n!!!");
                            }
                        }

                        if (playersHandValue >= BlackJackValue)
                        {
                            break;
                        }
                    }
                }

                else
                {
                    while (true)
                    {
                        if (playersHandValue < BlackJackValue && playersHandValue < MaxDealersHandValue)
                        {
                            player.Hand.AddRange(_deck.PopCards(1));
                            playersHandValue = player.GetHandValue();
                        }

                        else
                        {
                            break;
                        }
                    }
                }

            }
        }
    }
}
