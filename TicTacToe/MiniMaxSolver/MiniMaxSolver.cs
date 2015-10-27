using System;
using System.Collections.Generic;
using System.Linq;
using MiniMax.Interface;


namespace MiniMax
{
    public class MiniMaxSolver
    {
      public IMove CalculateBestMove(IState state, IPlayer player, IPlayer opponentPlayer)
      {
        Node root = new Node()
        {
          Pair = new MoveNextStatePair()
          {
            State = state,
            Move = null
          }
        };

        PopulateTree(root, player, opponentPlayer);

        int currentBestValue = Int32.MinValue;
        IMove currentBestMove = null;

        foreach (var node in root.ChildrenNodes)
        {
          // The next turn is the adversary turn
          int nodeValue = MiniMaxAlgo(node, player, true);
          Console.WriteLine("{0} --> {1}", node.Pair.Move.GetDescription(), nodeValue);
          if (nodeValue > currentBestValue)
          {
            currentBestValue = nodeValue;
            currentBestMove = node.Pair.Move;
          }
        }

        return currentBestMove;
      }

      private void PopulateTree(Node root, IPlayer playerTurn, IPlayer opponentPlayer)
      {
        List<MoveNextStatePair> childrens = root.Pair.State.GetPossibleStates(playerTurn).ToList();
        root.ChildrenNodes = childrens.Select(children => new Node()
        {
          Pair = children
        }).ToList();

        foreach (Node children in root.ChildrenNodes.Where(pair => !pair.Pair.State.IsGameOver))
        {
          PopulateTree(children, opponentPlayer, playerTurn);
        }
      }

      private int MiniMaxAlgo(Node root, IPlayer player, bool isAdversaryTurn)
      {
        if (root.Pair.State.IsGameOver)
        {
          return root.Pair.State.GetValueFor(player);
        }

        int bestCurrentValueForCurrentPlayerTurn = isAdversaryTurn ? int.MaxValue : int.MinValue;

        foreach (var node in root.ChildrenNodes)
        {
          int nodeValue = MiniMaxAlgo(node, player, !isAdversaryTurn);

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
