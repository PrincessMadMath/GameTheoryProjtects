using MiniMax;
using MiniMax.Interface;
using TicTacToe.Interface;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe
{
  public class IAPlayer : ITicTacToePlayer
  {
    public int Team { get; set; }
    public IToken Token { get; set; }
    public Strateger Strateger { get; set; }

    public IAPlayer(IToken token, int team)
    {
      Token = token;
      Team = team;
    }

    public TicTacToeMove GetMove(TicTacToeGame game)
    {
      IPlayer opponentPlayer = game.PlayerA == this ? game.PlayerB : game.PlayerA;

      var bestMove = Strateger.FindBestMove(game.GameState, this, opponentPlayer) as TicTacToeMove;
      return bestMove;
    }
  }
}