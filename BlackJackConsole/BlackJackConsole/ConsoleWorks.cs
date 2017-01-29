using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsole
{
    static class ConsoleWorks
    {
        public static void ShowPlayer(Player player)
        {
            if (player.Name != "Dealer")
            {
                Console.WriteLine($"Player {player.Name}, balance {player.Balance}.");
            }

            else
            {
                Console.WriteLine($"Player {player.Name}");
            }
        }

        public static void ShowAllPlayers(List<Player> players)
        {
            foreach (Player player in players)
            {
                ShowPlayer(player);
            }
        }

        public static void PrintPlayerPlayerStatus(Player player, PlayerStatus PlayerStatus)
        {
            if (PlayerStatus == PlayerStatus.Loose)
            {
                Console.WriteLine($"{player.Name} lost ");
            }

            if (PlayerStatus == PlayerStatus.Win)
            {
                Console.WriteLine($"{player.Name} Won");
            }

            if (PlayerStatus == PlayerStatus.BlackJack)
            {
                Console.WriteLine($"{player.Name} Blackjack");
            }

            if (PlayerStatus == PlayerStatus.Draw)
            {
                Console.WriteLine($"Draw {player.Name} -> Dealer");
            }
        }

        public static void ShowAllCards(List<Player> players)
        {
            Console.Clear();
            foreach (Player player in players)
            {
                ShowPlayersHand(player);
            }
        }

        public static void ShowPlayersHand(Player player)
        {
            ShowPlayer(player);
            if (player.Name != "Dealer")
            {
                foreach (Card card in player.Hand)
                {
                    Console.WriteLine(string.Format($"{card.Name.ToString()}{GetSuit(card)}"));
                }
                Console.WriteLine($"Hand value: {player.GetHandValue()}");
                Console.WriteLine($"Your bet is {player.Bet}");
                Console.WriteLine(new string('=', 10));
            }

            else
            {
                foreach (Card card in player.Hand)
                {
                    Console.WriteLine(string.Format($"{card.Name.ToString()}{GetSuit(card)}"));
                }
                Console.WriteLine($"Hand value: {player.GetHandValue()}");
                Console.WriteLine(new string('=', 10));
            }
        }

        public static int GetNumPlayers()
        {
            int playerNum = 0;
            while (true)
            {
                Console.WriteLine("Write number of players");
                Int32.TryParse(Console.ReadLine(), out playerNum);

                if (playerNum != 0 && playerNum < 6)
                {
                    playerNum++;
                    break;
                }
            }

            Console.Clear();
            return playerNum;
        }

        private static char GetSuit(Card card)
        {
            char _suit = ' ';

            if (card.Suit == Suits.Clubs)
            {
                _suit = '\u2663';
                return _suit;
            }

            if (card.Suit == Suits.Diamonds)
            {
                _suit = '\u2666';
                return _suit;
            }

            if (card.Suit == Suits.Hearts)
            {
                _suit = '\u2665';
                return _suit;
            }

            if (card.Suit == Suits.Spades)
            {
                _suit = '\u2660';
                return _suit;
            }

            return _suit;
        }
    }
}
