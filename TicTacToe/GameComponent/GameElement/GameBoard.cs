using System;
using GameComponent.Interface;
using GameComponent.Utils;

namespace GameComponent.GameElement
{
  public class GameBoard
  {
    private static int CASE_PADDING = 7;

    private IToken[,] _boards;
    public int BoardWidth{ get; private set; }
    public int BoardHeight { get; private set; }
  
    public GameBoard(int width, int height)
    {
      BoardWidth = width;
      BoardHeight = height;
      _boards = new IToken[BoardWidth, BoardHeight];
    }

    public IToken GetToken(int x, int y)
    {
      if (x < 0 || x >= BoardWidth || y < 0 || y >= BoardHeight)
      {
        return null;
      }
      return _boards[x, y];
    }

    // Return if the token was successfully add
    public bool TryAddToken(int x, int y, IToken token)
    {
      if (x < 0 || x >= BoardWidth || y < 0 || y >= BoardHeight)
      {
        return false;
      }
      _boards[x, y] = token;
      return true;
    }

    public void Display()
    {
      for (int x = 0; x < BoardWidth; x += 1)
      {
        Console.WriteLine(new String('-', BoardWidth * (CASE_PADDING + 2)));
        for (int y = 0; y < BoardHeight; y += 1)
        {
          string caseValue;
          IToken currentToken = _boards[x, y];
          if (currentToken != null)
          {
            caseValue = currentToken.GetDisplayValue().ToString();
          }
          else
          {
            caseValue = string.Format("({0},{1})", x, y);
          }
          Console.Write("|");
          Console.Write(caseValue.PadBoth(CASE_PADDING));
          Console.Write("|");
        }
        Console.WriteLine();
      }
      Console.WriteLine(new String('-', BoardWidth * (CASE_PADDING + 2)));
    }
  }
}
