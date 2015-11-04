namespace GameSolver.Component
{
  /// <summary>
  /// Represent a pair of the Move necessary to access the NextResolvableState
  /// </summary>
  public class MoveStateCombinaison
  {
    /// <summary>
    /// Accessible NextResolvableState
    /// </summary>
    public IResolvableState NextResolvableState { get; set; }
    /// <summary>
    /// Move need to go to the NextResolvableState
    /// </summary>
    public IMove Move { get; set; }
  }
}