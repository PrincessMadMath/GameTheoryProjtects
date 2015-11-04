using System.Collections.Generic;

namespace GameSolver.Component
{
  /// <summary>
  /// Represent a state of a game
  /// </summary>
  public interface IResolvableState
  {
    /// <summary>
    /// 
    /// </summary>
    bool IsGameOver();
    int GetValueFor(ITeamIdentifier player);
    IResolvableState Copy();

    List<MoveStateCombinaison> GetPossibleStates(ITeamIdentifier player);
  }
}