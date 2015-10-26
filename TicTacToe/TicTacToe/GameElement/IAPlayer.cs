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
    private MiniMaxSolver _miniMaxSolver;

    public IAPlayer(IToken token, int team)
    {
      Token = token;
      Team = team;
      _miniMaxSolver = new MiniMaxSolver();
    }

    public TicTacToeMove GetMove(TicTacToeGame game)
    {
      IPlayer opponentPlayer = game.PlayerA == this ? game.PlayerB : game.PlayerA;

      var bestMove = _miniMaxSolver.CalculateBestMove(game.GameState, this, opponentPlayer) as TicTacToeMove;
      return bestMove;
    }
  }
}