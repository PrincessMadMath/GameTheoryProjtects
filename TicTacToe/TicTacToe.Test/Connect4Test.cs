using System.Runtime.InteropServices.ComTypes;
using Connect4.GameElement;
using GameComponent.GameElement;
using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public class Connect4Test
    {
        [Test]
        public void Detect_HorizontalWin()
        {
            var tokenA = new Token(0, 'x');
            var tokenB = new Token(1, 'y');

            var state = new Connect4State(7, 6, tokenA, tokenB);

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 0
                }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 1
                }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 2
                }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 4
                }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 3
                }
            );

            Assert.IsTrue(state.IsGameOver());

        }

        [Test]
        public void Detect_VerticalWin()
        {
            var tokenA = new Token(0, 'x');
            var tokenB = new Token(1, 'y');

            var state = new Connect4State(7, 6, tokenA, tokenB);

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 1
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsTrue(state.IsGameOver());

        }

        [Test]
        public void DoesNotCountTheOpponent()
        {
            var tokenA = new Token(0, 'x');
            var tokenB = new Token(1, 'y');

            var state = new Connect4State(7, 6, tokenA, tokenB);

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenB,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

        }

        [Test]
        public void Detect_Diagonale1()
        {
            var tokenA = new Token(0, 'x');
            var tokenB = new Token(1, 'y');

            var state = new Connect4State(7, 6, tokenA, tokenB);

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenB,
                X = 1
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 1
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenB,
                X = 2
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 2
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 2
            }
            );

            Assert.IsFalse(state.IsGameOver());


            state.PlayMove(new Connect4Move()
            {
                Token = tokenB,
                X = 3
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 3
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 3
            }
            );


            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 3
            }
            );

            Assert.IsTrue(state.IsGameOver());

        }

        [Test]
        public void Detect_Diagonale2()
        {
            var tokenA = new Token(0, 'x');
            var tokenB = new Token(1, 'y');

            var state = new Connect4State(7, 6, tokenA, tokenB);

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 3
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenB,
                X = 2
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 2
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenB,
                X = 1
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 1
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 1
            }
            );

            Assert.IsFalse(state.IsGameOver());


            state.PlayMove(new Connect4Move()
            {
                Token = tokenB,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );


            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
            {
                Token = tokenA,
                X = 0
            }
            );

            Assert.IsTrue(state.IsGameOver());

        }

        [Test]
        public void DetectNull()
        {
            var tokenA = new Token(0, 'x');
            var tokenB = new Token(1, 'y');

            var state = new Connect4State(2, 2, tokenA, tokenB);

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 0
                }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 0
                }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 1
                }
            );

            Assert.IsFalse(state.IsGameOver());

            state.PlayMove(new Connect4Move()
                {
                    Token = tokenA,
                    X = 1
                }
            );

            Assert.IsTrue(state.IsGameOver());
        }
    }
}