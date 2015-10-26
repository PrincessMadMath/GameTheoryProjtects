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
      var game = new TicTacToeGame(3);
      game.Play();
      Console.ReadLine();
    }
  }
}
