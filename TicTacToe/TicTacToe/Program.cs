using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("*********** Nouvelle partie *************");
                var game = new TicTacToeGame(3);
                game.Play();
                Console.WriteLine("Commencer nouvelle partie (y/n)");
                string c = Console.ReadLine();
                if (c.ToLower() != "y")
                {
                    break;
                }
            }

        }
    }
}
