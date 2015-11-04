namespace GameSolver.Component
{
    public interface ISolver
    {
        IMove FindBestMove(IResolvableState resolvableState, ITeamIdentifier player, ITeamIdentifier opponentPlayer);
    }
}