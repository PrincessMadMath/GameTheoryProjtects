using System;
using GameSolver.Algo;
using NUnit.Framework;

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