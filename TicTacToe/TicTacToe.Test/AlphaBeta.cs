using System;
using MiniMax;
using MiniMax.Interface;
using NUnit.Framework;
using TicTacToe.Interface;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe.Test
{
    [TestFixture]
    public class AlphaBeta : StrategerBaseTest
    {
        public override Strateger GetStrateger()
        {
            return new Strateger()
            {
                Depth = Int32.MaxValue,
                NodeSolver = new AlphaBetaPrunning()
            };
        }
    }

}