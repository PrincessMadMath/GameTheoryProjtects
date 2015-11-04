using GameComponent.Interface;
using GameSolver.Component;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe.Player
{
  public interface ITicTacToePlayer : IPlayer
  {
    IToken Token { get; set; }
    TicTacToeMove GetMove(TicTacToeGame state);
  }
}