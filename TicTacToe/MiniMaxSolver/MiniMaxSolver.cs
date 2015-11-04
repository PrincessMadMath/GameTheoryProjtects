using System;
using System.Linq;
using MiniMax.Interface;


namespace MiniMax
{
    public class MiniMaxSolver : INodeSolver
    {
        public int CalculateNodeValue(Node root, IPlayer player, IPlayer opponentPlayer, bool isAdversaryTurn, int depth)
        {
            return MiniMaxAlgo(root, player,opponentPlayer, true);
        }

        private int MiniMaxAlgo(Node root, IPlayer player, IPlayer opponentPlayer, bool isAdversaryTurn)
        {
            IPlayer playingPlayer = isAdversaryTurn ? opponentPlayer : player;
            IPlayer otherPlayer = !isAdversaryTurn ? opponentPlayer : player;
            Helper.PopulateTree(root, playingPlayer, otherPlayer, 1);
            if (root.Combinaison.NextState.IsGameOver() || !root.ChildrenNodes.Any())
            {
                return root.Combinaison.NextState.GetValueFor(player);
            }

            int bestCurrentValueForCurrentPlayerTurn = isAdversaryTurn ? int.MaxValue : int.MinValue;

            foreach (var node in root.ChildrenNodes)
            {
                int nodeValue = MiniMaxAlgo(node, player, opponentPlayer, !isAdversaryTurn);

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
