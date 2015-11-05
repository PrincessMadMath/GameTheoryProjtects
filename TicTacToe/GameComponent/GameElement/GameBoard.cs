using System;
using GameComponent.Interface;
using GameComponent.Utils;

namespace GameComponent.GameElement
{
    public class GameBoard : IGameBoard
    {
        private static int CASE_PADDING = 7;

        private IToken[,] _boards;
        public int BoardWidth { get; private set; }
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
                throw new ArgumentException("Outbound position");
            }
            return _boards[x, y];
        }

        // Return if the token was successfully add
        public bool TryAddToken(int x, int y, IToken token)
        {
            if (x < 0 || x >= BoardWidth || y < 0 || y >= BoardHeight)
            {
                throw new ArgumentException("Outbound position");
            }
            _boards[x, y] = token;
            return true;
        }

        public IGameBoard Copy()
        {
            var copy = new GameBoard(BoardWidth, BoardHeight);
            for (int i = 0; i < BoardHeight; i++)
            {
                for (int j = 0; j < BoardWidth; j++)
                {
                    copy.TryAddToken(i, j, GetToken(i, j));
                }
            }
            return copy;
        }

    }
}
