using MiniMax;
using MiniMax.Interface;
using NUnit.Framework;
using TicTacToe.Interface;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe.Test
{
    [TestFixture]
    public class MiniMaxTest
    {
        [Test]
        public void WillTakeWinningOpportunity()
        {
            var state = new TicTacTocState(3);

            IToken tokenX = new Token(1, 'X');
            IPlayer opponent = new IAPlayer(tokenX, 1);

            IToken tokenY = new Token(2, 'Y');
            IPlayer player = new IAPlayer(tokenY, 2);

            var solver = new MiniMaxSolver();

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 1,
                Token = tokenY
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 1,
                Token = tokenY
            });
            Assert.IsFalse(state.IsGameOver);
            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 0,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver);
            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 2,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver);


            var move = solver.CalculateBestMove(state, player, opponent) as TicTacToeMove;
            Assert.IsNotNull(move);
            Assert.IsFalse(state.IsGameOver);
            Assert.AreEqual(2, move.X);
            Assert.AreEqual(1, move.Y);
        }

        [Test]
        public void NotLoosingTest()
        {
            var state = new TicTacTocState(3);

            IToken tokenX = new Token(1, 'X');
            IPlayer opponent = new IAPlayer(tokenX, 1);

            IToken tokenY = new Token(2, 'Y');
            IPlayer player = new IAPlayer(tokenY, 2);

            var solver = new MiniMaxSolver();

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 1,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 1,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 0,
                Token = tokenY
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 2,
                Token = tokenY
            });
            Assert.IsFalse(state.IsGameOver);

            var move = solver.CalculateBestMove(state, player, opponent) as TicTacToeMove;
            Assert.IsNotNull(move);
            Assert.IsFalse(state.IsGameOver);
            Assert.AreEqual(2, move.X);
            Assert.AreEqual(1, move.Y);
        }

        [Test]
        public void EndGameSituation()
        {
            var state = new TicTacTocState(3);

            IToken tokenY = new Token(2, 'Y');
            IPlayer player = new IAPlayer(tokenY, 2);

            IToken tokenX = new Token(1, 'X');
            IPlayer opponent = new IAPlayer(tokenX, 2);

            var solver = new MiniMaxSolver();

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 1,
                Token = tokenY
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 1,
                Token = tokenY
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 1,
                Token = tokenY
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 0,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 0,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 2,
                Y = 2,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver);

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 2,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver);

            var move = solver.CalculateBestMove(state, player, opponent) as TicTacToeMove;
            Assert.IsNotNull(move);
            Assert.IsFalse(state.IsGameOver);
            Assert.AreEqual(2, move.X);
            Assert.AreEqual(1, move.Y);
        }
    }
}