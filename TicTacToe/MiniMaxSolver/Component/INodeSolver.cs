namespace GameSolver.Component
{
    public interface INodeSolver
    {
        int CalculateNodeValue(Node root, ITeamIdentifier player, ITeamIdentifier opponentPlayer, bool isAdversaryTurn, int depth); 
    }
}