using System.Collections.Generic;

namespace MiniMax.Interface
{
  public interface IState
  {
    bool IsGameOver { get; }
    int GetValueFor(IPlayer player);
    IState Copy();

    List<MoveNextStatePair> GetPossibleStates(IPlayer player);
  }
}