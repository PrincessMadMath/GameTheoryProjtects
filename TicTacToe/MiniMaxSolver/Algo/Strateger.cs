﻿using System;
using System.Diagnostics;
using GameSolver.Component;

namespace GameSolver.Algo
{
    public class Strateger : ISolver
    {
        public int Depth { get; set; }
        public INodeSolver NodeSolver { get; set; }

        public Strateger()
        {
        }

        public Strateger(int depth, INodeSolver solver)
        {
            Depth = depth;
            NodeSolver = solver;
        }

        public IMove FindBestMove(IResolvableState resolvableState, ITeamIdentifier player, ITeamIdentifier opponentPlayer)
        {
            Node root = new Node()
            {
                Combinaison = new MoveStateCombinaison()
                {
                    NextResolvableState = resolvableState,
                    Move = null
                }
            };

            Helper.PopulateTree(root, player, opponentPlayer, 1);

            int currentBestValue = Int32.MinValue;
            IMove currentBestMove = null;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            foreach (var node in root.ChildrenNodes)
            {
                // The next turn is the adversary turn
                int nodeValue = NodeSolver.CalculateNodeValue(node, player, opponentPlayer, true, Depth);
                Console.WriteLine("{0} --> {1}", node.Combinaison.Move.GetDescription(), nodeValue);
                if (nodeValue > currentBestValue)
                {
                    currentBestValue = nodeValue;
                    currentBestMove = node.Combinaison.Move;
                }
            }

            watch.Stop();
            Console.WriteLine("Elapse time: {0}", watch.ElapsedMilliseconds);

            return currentBestMove;
        }


    }
}