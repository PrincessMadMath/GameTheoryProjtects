using MiniMax.Interface;


namespace MiniMax
{
  public class MoveNextStatePair
  {
    public IState State { get; set; }
    public IMove Move { get; set; }
  }
}