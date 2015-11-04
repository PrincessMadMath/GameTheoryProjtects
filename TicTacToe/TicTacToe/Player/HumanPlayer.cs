using GameComponent.Interface;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe.Player
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
      int x = GameComponent.Utils.Utils.GetIntFromConsole("Entrer valeur de x:");
      int y = GameComponent.Utils.Utils.GetIntFromConsole("Entrer valeur de y:");
      return new TicTacToeMove()
      {
        Token = Token,
        X = x,
        Y = y
      };
    }
  }
}