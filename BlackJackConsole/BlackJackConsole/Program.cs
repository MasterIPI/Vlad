using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BlackJackConsole.ConsoleWorks;

namespace BlackJackConsole
{
    public class Program
    {
        static void Main()
        {
            Game NewGame = new Game();
            Console.OutputEncoding = Encoding.UTF8;

            NewGame.PlayGame(GetHumanPlayersNumber());
        }
    }
}
