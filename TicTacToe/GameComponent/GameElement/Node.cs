using System.Collections.Generic;
using GameSolver.Component;

namespace GameComponent.GameElement
{
  /// <summary>
  /// Represent a node for the MiniMax algorithm
  /// </summary>
  public class Node
  {
    /// <summary>
    /// Represent the current state and the move to get to this state
    /// </summary>
    public MoveStateCombinaison Combinaison { get; set; }

    /// <summary>
    /// All the accessible Node from this one
    /// </summary>
    public List<Node> ChildrenNodes { get; set; }
  }
}