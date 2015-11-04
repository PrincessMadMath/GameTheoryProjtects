using GameSolver.Algo;

namespace GameSolver
{
    public static class StrategyResolver
    {
        public static Strateger GetStrateger()
        {
            return new Strateger()
            {
                Depth = 16,
                NodeSolver = new AlphaBetaPrunning()
            };
        }
    }
}