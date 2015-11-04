using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MiniMax.Interface;


namespace MiniMax
{
    public class AlphaBetaPrunning : INodeSolver
    {
        public int CalculateNodeValue(Node root, IPlayer player, IPlayer opponentPlayer, bool isAdversaryTurn, int depth)
        {
            return AlphaBetaAlgo(root, player, opponentPlayer, Int32.MinValue, Int32.MaxValue, true);
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
        private int AlphaBetaAlgo(Node root, IPlayer player, IPlayer opponentPlayer, int alpha, int beta, bool isAdversaryTurn)
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
                int nodeValue = AlphaBetaAlgo(node, player, opponentPlayer, alpha, beta, !isAdversaryTurn);

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
