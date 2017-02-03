using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BlackJackConsole.ConsoleWorks;

namespace BlackJackConsole
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            PlayGame(GetNumPlayers());
        }

        static void PlayGame(int playerNum)
        {
            string answer = string.Empty;

            Deck deck = new Deck();
            deck.Shuffle();

            List<Player> players = new List<Player>(playerNum);

            GetPlayersNames(players);
            GetPlayersBets(players, ref deck);

            ShowAllCards(players);
            PlayHand(players, ref deck);
            GetWinner(players);
            Console.ReadKey();
        }

        static void GetWinner(List<Player> players)
        {
            ShowAllCards(players);

            int[] values = new int[players.Count];

            for (int i = 0; i < players.Count; i++)
            {
                values[i] = players[i].GetHandValue();
            }

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > 21)
                {
                    Player current = players[i];
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerPlayerStatus(players[i], PlayerStatus.Loose);
                }

                if (values[i] == 21)
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerPlayerStatus(players[i], PlayerStatus.BlackJack);
                }

                if (values[i] == values[0])
                {
                    Player current = players[i];
                    current.Balance += current.Bet;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerPlayerStatus(players[i], PlayerStatus.Draw);
                }

                if ((values[i] > values[0]) && (values[i] < 21) && (values[0] < 21))
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerPlayerStatus(players[i], PlayerStatus.Win);
                }

                if ((values[i] < values[0]) && (values[0] > 21) && (values[i] < 21))
                {
                    Player current = players[i];
                    current.Balance += current.Bet * 2;
                    current.Bet = 0;
                    players[i] = current;
                    PrintPlayerPlayerStatus(players[i], PlayerStatus.Win);
                }
            }

            ShowAllPlayers(players);
        }

        static void PlayHand(List<Player> players, ref Deck deck)
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
                        if (playersHandValue < 21)
                        {
                            ShowAllCards(players);
                            Console.WriteLine($"{player.Name}, do you want to pick a card? (y/n)");
                            answer = Console.ReadLine();

                            if (answer == "y")
                            {
                                player.Hand.AddRange(deck.PopCards(1));
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

                        if (playersHandValue >= 21)
                        {
                            break;
                        }
                    }
                }

                else
                {
                    while (true)
                    {
                        if (playersHandValue < 21 && playersHandValue < 17)
                        {
                            player.Hand.AddRange(deck.PopCards(1));
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
