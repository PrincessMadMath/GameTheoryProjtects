
using MiniMax.Interface;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe.Interface
{
  public interface ITicTacToePlayer : IPlayer
  {
    IToken Token { get; set; }
    TicTacToeMove GetMove(TicTacToeGame state);
  }
}