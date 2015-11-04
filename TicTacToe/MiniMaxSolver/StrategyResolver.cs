namespace MiniMax
{
    public static class StrategyResolver
    {
        public static Strateger GetStrateger()
        {
            return new Strateger()
            {
                Depth = 16,
                NodeSolver = new MiniMaxSolver()
            };
        }
    }
}