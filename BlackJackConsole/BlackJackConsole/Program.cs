using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int playerNum = 0;

            while (true)
            {
                Console.WriteLine("Write number of players");
                Int32.TryParse(Console.ReadLine(), out playerNum);

                if (playerNum != 0 && playerNum < 6)
                {
                    Console.WriteLine($"Number of players = {playerNum}");
                    playerNum++;
                    break;
                }
            }

            PlayGame(playerNum);
            Console.ReadKey();
        }

        static void PlayGame(int playerNum)
        {
            Console.Clear();

            string answer = string.Empty;
            int bet = 0;

            Deck deck = new Deck();
            deck.Shuffle();

            List<Player> players = new List<Player>(playerNum);

            players.Add(new Player("Dealer"));

            for (int i = 1; i < playerNum; i++)
            {
                Console.WriteLine($"Write name for player {i}");
                players.Add(new Player(Console.ReadLine()));
            }

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Name != "Dealer")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"{players[i].Name}, your balance = {players[i].Balance} how much would you bet?");
                        Int32.TryParse(Console.ReadLine(), out bet);

                        if (bet != 0 && bet <= players[i].Balance)
                        {
                            Player current = players[i];
                            current.Bet = bet;
                            current.Balance = current.Balance - bet;
                            players[i] = current;
                            players[i].GetHand.AddRange(deck.PopCards(2));
                            break;
                        }
                    }
                }

                else
                {
                    players[i].GetHand.AddRange(deck.PopCards(2));
                }
            }

            ShowCards(players);
            PlayHand(players, deck);
            GetWinner(players);
        }

        static void ShowCards(List<Player> players)
        {
            Console.Clear();
            foreach (Player player in players)
            {
                player.ShowHand();
            }
        }

        static void GetWinner(List<Player> players)
        {
            ShowCards(players);

            int[] values = new int[players.Count];

            for (int i = 0; i < players.Count; i++)
            {
                values[i] = players[i].GetHandValue();
            }

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > 21)
                {
                    if (i != 0)
                    {
                        Player current = players[i];
                        current.Bet = 0;
                        players[i] = current;
                    }
                    Console.WriteLine($"{players[i].Name} lost");
                }

                else if (values[i] == 21)
                {
                    if (i != 0)
                    {
                        Player current = players[i];
                        current.Balance += current.Bet * 2;
                        current.Bet = 0;
                        players[i] = current;
                    }
                    Console.WriteLine($"{players[i].Name} Blackjack");
                }

                else if (values[i] == values[0])
                {
                    if (i != 0)
                    {
                        Player current = players[i];
                        current.Balance += current.Bet;
                        current.Bet = 0;
                        players[i] = current;
                    }
                    Console.WriteLine($"Draw {players[i].Name} -> {players[0].Name}");
                }
            }

            foreach (Player player in players)
            {
                if (player.Name != "Dealer")
                {
                    Console.WriteLine($"Player {player.Name}, balance = {player.Balance}");
                }
            }
        }

        static void PlayHand(List<Player> players, Deck deck)
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
                            ShowCards(players);
                            Console.WriteLine($"{player.Name}, do you want to pick a card? (y/n)");
                            answer = Console.ReadLine();

                            if (answer == "y")
                            {
                                player.GetHand.AddRange(deck.PopCards(1));
                                player.ShowHand();
                                playersHandValue = player.GetHandValue();
                            }

                            else if (answer == "n")
                            {
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Please, type y or n!!!");
                            }
                        }

                        else if (playersHandValue == 21)
                        {
                            break;
                        }

                        else if (playersHandValue > 21)
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
                            player.GetHand.AddRange(deck.PopCards(1));
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
