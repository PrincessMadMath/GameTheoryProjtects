using MiniMax.Interface;
using NUnit.Framework;
using TicTacToe.Interface;
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
        Assert.IsFalse(state.IsGameOver);

        IToken token = new Token(1, 'X');

        state.PlayMove(new TicTacToeMove()
        {
          X = 0, 
          Y = 0, 
          Token = token
        });
        Assert.IsFalse(state.IsGameOver);

        state.PlayMove(new TicTacToeMove()
        {
          X = 1,
          Y = 0,
          Token = token
        });
        Assert.IsFalse(state.IsGameOver);

        state.PlayMove(new TicTacToeMove()
        {
          X = 2,
          Y = 0,
          Token = token
        });

        Assert.IsTrue(state.IsGameOver);
      }

      [Test]
      public void TestVerticallWin()
      {
        var state = new TicTacTocState(3);
        Assert.IsFalse(state.IsGameOver);

        IToken token = new Token(1, 'X');

        state.PlayMove(new TicTacToeMove()
        {
          X = 0,
          Y = 0,
          Token = token
        });
        Assert.IsFalse(state.IsGameOver);

        state.PlayMove(new TicTacToeMove()
        {
          X = 0,
          Y = 1,
          Token = token
        });
        Assert.IsFalse(state.IsGameOver);

        state.PlayMove(new TicTacToeMove()
        {
          X = 0,
          Y = 2,
          Token = token
        });

        Assert.IsTrue(state.IsGameOver);
      }

      [Test]
      public void TestDiagonale()
      {
        var state = new TicTacTocState(3);
        Assert.IsFalse(state.IsGameOver);

        IToken token = new Token(1, 'X');
        IToken tokenEnnemy = new Token(1, 'X');

        state.PlayMove(new TicTacToeMove()
        {
          X = 0,
          Y = 0,
          Token = token
        });
        Assert.IsFalse(state.IsGameOver);

        state.PlayMove(new TicTacToeMove()
        {
          X = 1,
          Y = 1,
          Token = token
        });
        Assert.IsFalse(state.IsGameOver);

        state.PlayMove(new TicTacToeMove()
        {
          X = 2,
          Y = 2,
          Token = token
        });

        Assert.IsTrue(state.IsGameOver);
      }

      [Test]
      public void TestDiagonaleWithOponent()
      {
        var state = new TicTacTocState(3);
        Assert.IsFalse(state.IsGameOver);

        IToken token = new Token(1, 'X');
        IToken tokenEnnemy = new Token(2, 'X');

        state.PlayMove(new TicTacToeMove()
        {
          X = 0,
          Y = 0,
          Token = token
        });
        Assert.IsFalse(state.IsGameOver);

        state.PlayMove(new TicTacToeMove()
        {
          X = 1,
          Y = 1,
          Token = token
        });
        Assert.IsFalse(state.IsGameOver);

        state.PlayMove(new TicTacToeMove()
        {
          X = 2,
          Y = 2,
          Token = tokenEnnemy
        });

        Assert.IsFalse(state.IsGameOver);
      }

      [Test]
      public void AccessibleStateTest()
      {
        var state = new TicTacTocState(2);
        Assert.IsFalse(state.IsGameOver);

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
