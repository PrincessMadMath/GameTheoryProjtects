using System.Collections.Generic;

namespace MiniMax
{
  public class Node
  {
    public MoveNextStatePair Pair { get; set; }
    public List<Node> ChildrenNodes { get; set; }
  }
}