using GameComponent.Interface;
using GameSolver.Component;

namespace TicTacToe.TicTacToeGameElement
{
  public class TicTacToeMove : IMove
  {
    public int X { get; set; }
    public int Y { get; set; }
    public IToken Token { get; set; }

    public string GetDescription()
    {
      return string.Format("Placement d'un token à position ({0}, {1})", X, Y);
    }
  }
}