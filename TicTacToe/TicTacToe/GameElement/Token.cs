using TicTacToe.Interface;

namespace TicTacToe
{
  public class Token : IToken
  {
    private readonly char _displayValue;
    public int Team { get; set; }

    public Token(int team, char displayValue)
    {
      Team = team;
      _displayValue = displayValue;
    }

    public char GetDisplayValue()
    {
      return _displayValue;
    }
  }
}