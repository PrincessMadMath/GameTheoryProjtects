using System;
using System.Linq;
using GameSolver.Component;

namespace GameSolver.Algo
{
    public class AlphaBetaPrunning : INodeSolver
    {
        public int CalculateNodeValue(Node root, ITeamIdentifier player, ITeamIdentifier opponentPlayer, bool isAdversaryTurn, int depth)
        {
            return AlphaBetaAlgo(root, player, opponentPlayer, Int32.MinValue, Int32.MaxValue, true, depth);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="player"></param>
        /// <param name="opponentPlayer"></param>
        /// <param name="alpha">Best already explored option along path to the root for the maximizer</param>
        /// <param name="beta">Best already explored option along path to the root for the minimizer</param>
        /// <param name="isAdversaryTurn"></param>
        /// <returns></returns>
        private int AlphaBetaAlgo(Node root, ITeamIdentifier player, ITeamIdentifier opponentPlayer, int alpha, int beta, bool isAdversaryTurn, int depth)
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
                int nodeValue = AlphaBetaAlgo(node, player, opponentPlayer, alpha, beta, !isAdversaryTurn, depth);

                // Minimizer
                if (isAdversaryTurn)
                {
                    bestCurrentValueForCurrentPlayerTurn = Math.Min(nodeValue, bestCurrentValueForCurrentPlayerTurn);

                    beta = Math.Min(bestCurrentValueForCurrentPlayerTurn, beta);

                    if (beta < alpha)
                    {
                        return beta;
                    }
                }
                // Maximizer
                else
                {
                    bestCurrentValueForCurrentPlayerTurn = Math.Max(nodeValue, bestCurrentValueForCurrentPlayerTurn);

                    alpha = Math.Max(bestCurrentValueForCurrentPlayerTurn, alpha);

                    if (alpha > beta)
                    {
                        return alpha;
                    }
                }
            }
            return bestCurrentValueForCurrentPlayerTurn;
        }


    }
}
