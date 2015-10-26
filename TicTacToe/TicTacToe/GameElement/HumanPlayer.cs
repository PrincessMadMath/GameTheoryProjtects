using System;
using System.Dynamic;
using TicTacToe.Interface;
using TicTacToe.TicTacToeGameElement;
using TicTacToe.Utils;

namespace TicTacToe
{
  public class HumanPlayer : ITicTacToePlayer
  {
    public int Team { get; set; }
    public IToken Token { get; set; }

    public HumanPlayer(IToken token, int team)
    {
      Token = token;
      Team = team;
    }

    public TicTacToeMove GetMove(TicTacToeGame game)
    {
      int x = Utils.Utils.GetIntFromConsole("Entrer valeur de x:");
      int y = Utils.Utils.GetIntFromConsole("Entrer valeur de y:");
      return new TicTacToeMove()
      {
        Token = Token,
        X = x,
        Y = y
      };
    }
  }
}