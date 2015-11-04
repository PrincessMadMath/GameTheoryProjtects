using GameSolver.Component;

namespace GameComponent.Interface
{
    public interface IPlayer : ITeamIdentifier
    {
        IToken Token { get; set; }
        IMove GetMove(IGameInfo game);
    }
}