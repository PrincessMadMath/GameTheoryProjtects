using System;
using System.Linq;
using GameSolver.Component;

namespace GameSolver.Algo
{
    public class MiniMaxSolver : INodeSolver
    {
        public int CalculateNodeValue(Node root, ITeamIdentifier player, ITeamIdentifier opponentPlayer, bool isAdversaryTurn, int depth)
        {
            return MiniMaxAlgo(root, player,opponentPlayer, true, depth);
        }

        private int MiniMaxAlgo(Node root, ITeamIdentifier player, ITeamIdentifier opponentPlayer, bool isAdversaryTurn, int depth)
        {
            ITeamIdentifier playingPlayer = isAdversaryTurn ? opponentPlayer : player;
            ITeamIdentifier otherPlayer = !isAdversaryTurn ? opponentPlayer : player;
            Helper.PopulateTree(root, playingPlayer, otherPlayer, 1);
            if (root.Combinaison.NextResolvableState.IsGameOver() || !root.ChildrenNodes.Any() || depth == 0)
            {
                return root.Combinaison.NextResolvableState.GetValueFor(player);
            }
            --depth;

            int bestCurrentValueForCurrentPlayerTurn = isAdversaryTurn ? int.MaxValue : int.MinValue;

            foreach (var node in root.ChildrenNodes)
            {
                int nodeValue = MiniMaxAlgo(node, player, opponentPlayer, !isAdversaryTurn, depth);

                // Find min
                if (isAdversaryTurn)
                {
                    bestCurrentValueForCurrentPlayerTurn = Math.Min(nodeValue, bestCurrentValueForCurrentPlayerTurn);
                }
                // Find max
                else
                {
                    bestCurrentValueForCurrentPlayerTurn = Math.Max(nodeValue, bestCurrentValueForCurrentPlayerTurn);
                }
            }

            return bestCurrentValueForCurrentPlayerTurn;
        }
    }
}
