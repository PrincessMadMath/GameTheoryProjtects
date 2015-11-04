namespace GameSolver.Component
{
    public interface INodeSolver
    {
        int CalculateNodeValue(Node root, IPlayer player, IPlayer opponentPlayer, bool isAdversaryTurn, int depth); 
    }
}