using System.Collections.Generic;
using System.Linq;

namespace GameSolver.Component
{
    public static class Helper
    {
        public static void PopulateTree(Node root, IPlayer playerTurn, IPlayer opponentPlayer, int depthAvailable)
        {
            if (depthAvailable == 0)
            {
                root.ChildrenNodes = new List<Node>();
                return;
            }

            List<MoveStateCombinaison> childrens = root.Combinaison.NextState.GetPossibleStates(playerTurn).ToList();
            root.ChildrenNodes = childrens.Select(children => new Node()
            {
                Combinaison = children
            }).ToList();

            foreach (Node children in root.ChildrenNodes.Where(pair => !pair.Combinaison.NextState.IsGameOver()))
            {
                PopulateTree(children, opponentPlayer, playerTurn, depthAvailable - 1);
            }
        }
    }
}