using GameComponent.GameElement;
using GameComponent.Interface;
using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public abstract class BoardBaseTest
    {
        public abstract IGameBoard GetBoard(int width, int height, IToken playerA, IToken playerB);

        [Test]
        public void AddToken_TokenIsRetrievable()
        {
            var tokenA = new Token(0, 'x');
            var tokenB = new Token(1, 'y');
            var board = GetBoard(6, 6, tokenA, tokenB);

            Assert.IsNull(board.GetToken(0, 0));
            Assert.IsNull(board.GetToken(3, 3));

            board.TryAddToken(0, 0, tokenA);

            Assert.AreEqual(tokenA, board.GetToken(0, 0));
            Assert.IsNull(board.GetToken(5, 5));

            board.TryAddToken(5, 5, tokenB);
            Assert.AreEqual(tokenA, board.GetToken(0, 0));
            Assert.AreEqual(tokenB, board.GetToken(5, 5));
        }
    }
}