using System;
using System.Collections.Generic;
using System.Linq;
using GameComponent.Interface;
using GameSolver.Component;

namespace GameComponent.GameElement
{
    /*
        .  .  .  .  .  .  .  TOP
        6 14 22 30 38 46 54
        5 12 19 26 33 40 47
        4 11 18 25 32 39 46
        3 10 17 24 31 38 45
        2  9 16 23 30 37 44
        1  8 15 22 29 36 43
        0  7 14 21 28 35 42  BOTTOM
     * */

    public class OptimizeGameBoard : IGameBoard, IGameOverDetector
    {
        private enum PlayerIdentifier
        {
            P1,
            P2
        }

        private const int MAX_SIZE = 7;

        Dictionary<IToken, PlayerIdentifier> _identifiers = new Dictionary<IToken, PlayerIdentifier>();
        private Int64 _bitBoardP1;
        private Int64 _bitBoardP2;

        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }

        public OptimizeGameBoard(int width, int height, IToken player1, IToken player2)
        {
            if (width < 0 || width > MAX_SIZE || height < 0 || height > MAX_SIZE)
            {
                throw new ArgumentException("Not valid size for the optimize board");
            }

            BoardWidth = width;
            BoardHeight = height;
            _bitBoardP1 = 0;
            _bitBoardP2 = 0;

            _identifiers.Add(player1, PlayerIdentifier.P1);
            _identifiers.Add(player2, PlayerIdentifier.P2);
        }

        public IToken GetToken(int x, int y)
        {
            if (x < 0 || x >= BoardWidth || y < 0 || y >= BoardHeight)
            {
                throw new ArgumentException("Outbound position");
            }

            IToken foundToken = null;

            int bitPosition = GetBitPosition(x, y);
            if (IsBiteSet(_bitBoardP1, bitPosition))
            {
                foundToken = GetTokenFromPlayer(PlayerIdentifier.P1);
            }
            else if (IsBiteSet(_bitBoardP2, bitPosition))
            {
                foundToken = GetTokenFromPlayer(PlayerIdentifier.P2);
            }

            return foundToken;;
        }

        public bool TryAddToken(int x, int y, IToken token)
        {
            if (x < 0 || x >= BoardWidth || y < 0 || y >= BoardHeight)
            {
                throw new ArgumentException("Outbound position");
            }

            if (GetToken(x, y) != null || !_identifiers.ContainsKey(token))
            {
                return false;
            }

            int bitPosition = GetBitPosition(x, y);

            switch (_identifiers[token])
            {
                case PlayerIdentifier.P1:
                    _bitBoardP1 = SetBit(_bitBoardP1, bitPosition);
                    break;

                case PlayerIdentifier.P2:
                    _bitBoardP2 = SetBit(_bitBoardP2, bitPosition);
                    break;
            }

            return true;
        }

        public IGameBoard Copy()
        {
            var tokenP1 = GetTokenFromPlayer(PlayerIdentifier.P1);
            var tokenP2 = GetTokenFromPlayer(PlayerIdentifier.P2);

            var copy = new OptimizeGameBoard(BoardWidth, BoardHeight, tokenP1, tokenP2);
            copy._bitBoardP1 = _bitBoardP1;
            copy._bitBoardP2 = _bitBoardP2;

            return copy;
        }

        private int GetBitPosition(int x, int y)
        {
            return x * 7 + y;
        }

        private bool IsBiteSet(Int64 b, int pos)
        {
            Int64 i = 1;
            return (b & (i << pos)) != 0;
        }

        private Int64 SetBit(Int64 b, int pos)
        {
            Int64 i = 1;
            return b | (i << pos);
        }

        private IToken GetTokenFromPlayer(PlayerIdentifier identifier)
        {
            return _identifiers.FirstOrDefault(v => v.Value == identifier).Key;
        }


        // BIG HACK
        public int? GetWinningTeam()
        {
            if (HasWon(_bitBoardP1))
            {
                return GetTokenFromPlayer(PlayerIdentifier.P1).Team;
            }
            else if (HasWon(_bitBoardP2))
            {
                return GetTokenFromPlayer(PlayerIdentifier.P2).Team;
            }
            else
            {
                return null;
            }
        }

        public static bool HasWon(Int64 board)
        {
            Int64 y = board & (board >> 6);
            if ((y & (y >> 2*6)) != 0) // check \ diagonal
            {
                return true;
            }
            y = board & (board >> 7);
            if ((y & (y >> 2*7)) != 0) // check horizontal
            {
                return true;
            }
            y = board & (board >> 8);
            if ((y & (y >> 2 * 8)) != 0)     // check / diagonal
            {
                return true;
            }
            y = board & (board >> 1);
            if ((y & (y >> 2)) != 0)         // check vertical
            {
                return true;
            }
            return false;
        }
    }
}