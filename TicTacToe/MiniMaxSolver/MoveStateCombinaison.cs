using MiniMax.Interface;


namespace MiniMax
{
  /// <summary>
  /// Represent a pair of the Move necessary to access the NextState
  /// </summary>
  public class MoveStateCombinaison
  {
    /// <summary>
    /// Accessible NextState
    /// </summary>
    public IState NextState { get; set; }
    /// <summary>
    /// Move need to go to the NextState
    /// </summary>
    public IMove Move { get; set; }
  }
}