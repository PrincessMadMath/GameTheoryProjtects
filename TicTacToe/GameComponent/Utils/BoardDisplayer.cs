using System;
using GameComponent.Interface;

namespace GameComponent.Utils
{
    public static  class BoardDisplayer
    {
        private static int CASE_PADDING = 7;

        public static void Display(IGameBoard board)
        {
            for (int y = board.BoardHeight - 1; y >= 0 ; --y)
            {
                Console.WriteLine(new String('-', board.BoardWidth * (CASE_PADDING + 2)));
                for (int x = 0; x < board.BoardWidth; x += 1)
                {
                    string caseValue;
                    IToken currentToken = board.GetToken(x, y);
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
            Console.WriteLine(new String('-', board.BoardWidth * (CASE_PADDING + 2)));
        }
    }
}