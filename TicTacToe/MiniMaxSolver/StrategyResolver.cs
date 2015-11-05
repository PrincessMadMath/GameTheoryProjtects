using GameSolver.Algo;

namespace GameSolver
{
    public static class StrategyResolver
    {
        public static Strateger GetStrateger(int depth = 5)
        {
            return new Strateger()
            {
                Depth = depth,
                NodeSolver = new AlphaBetaPrunning()
            };
        }
    }
}