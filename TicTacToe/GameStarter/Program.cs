using System;

namespace GameStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("*********** Nouvelle partie *************");
                var game = GameFactory.GetGame(GameFactory.GameType.Connect4);
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
