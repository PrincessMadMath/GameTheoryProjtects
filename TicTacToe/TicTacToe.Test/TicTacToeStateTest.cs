using GameComponent.GameElement;
using GameComponent.Interface;
using GameSolver.Component;
using NUnit.Framework;
using TicTacToe.Player;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeStateTest
    {
        [Test]
        public void TestClone_NotSameReference()
        {
            var state = new TicTacTocState(5);
            var clone = state.Copy();
            Assert.AreNotEqual(clone, state);
        }

        [Test]
        public void TestHorizontalWin()
        {
            var state = new TicTacTocState(3);
            Assert.IsFalse(state.IsGameOver());

            IToken token = new Token(1, 'X');

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 0,
                Token = token
            });
            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 0,
                Token = token
            });
            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new TicTacToeMove()
            {
                X = 2,
                Y = 0,
                Token = token
            });

            Assert.IsTrue(state.IsGameOver());
        }

        [Test]
        public void TestVerticallWin()
        {
            var state = new TicTacTocState(3);
            Assert.IsFalse(state.IsGameOver());

            IToken token = new Token(1, 'X');

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 0,
                Token = token
            });
            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 1,
                Token = token
            });
            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 2,
                Token = token
            });

            Assert.IsTrue(state.IsGameOver());
        }

        [Test]
        public void TestDiagonale()
        {
            var state = new TicTacTocState(3);
            Assert.IsFalse(state.IsGameOver());

            IToken token = new Token(1, 'X');
            IToken tokenEnnemy = new Token(2, 'O');

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 0,
                Token = token
            });
            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 1,
                Token = token
            });
            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new TicTacToeMove()
            {
                X = 2,
                Y = 2,
                Token = token
            });

            Assert.IsTrue(state.IsGameOver());
        }

        [Test]
        public void TestDiagonaleWithOponent()
        {
            var state = new TicTacTocState(3);
            Assert.IsFalse(state.IsGameOver());

            IToken tokenX = new Token(1, 'X');
            IPlayer opponent = new IAPlayer(tokenX, 1);

            IToken tokenO = new Token(2, 'O');
            IPlayer player = new IAPlayer(tokenO, 2);

            state.PlayMove(new TicTacToeMove()
            {
                X = 2,
                Y = 0,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 2,
                Token = tokenX
            });
            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 0,
                Token = tokenO
            });
            state.PlayMove(new TicTacToeMove()
            {
                X = 2,
                Y = 2,
                Token = tokenO
            });

            state.PlayMove(new TicTacToeMove()
            {
                X = 1,
                Y = 1,
                Token = tokenX
            });
            Assert.IsTrue(state.IsGameOver());
            Assert.AreEqual(1, state.GetValueFor(opponent));
            Assert.AreEqual(-1, state.GetValueFor(player));
        }

        [Test]
        public void AccessibleStateTest()
        {
            var state = new TicTacTocState(2);
            Assert.IsFalse(state.IsGameOver());

            IToken token = new Token(1, 'X');
            IPlayer player = new HumanPlayer(token, 1);

            var list = state.GetPossibleStates(player);

            Assert.AreEqual(4, list.Count);

            state.PlayMove(new TicTacToeMove()
            {
                X = 0,
                Y = 0,
                Token = token
            });

            list = state.GetPossibleStates(player);
            Assert.AreEqual(3, list.Count);
        }
    }
}
