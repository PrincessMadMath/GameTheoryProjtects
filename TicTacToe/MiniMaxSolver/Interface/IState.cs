﻿using System.Collections.Generic;

namespace MiniMax.Interface
{
  /// <summary>
  /// Represent a state of a game
  /// </summary>
  public interface IState
  {
    /// <summary>
    /// 
    /// </summary>
    bool IsGameOver();
    int GetValueFor(IPlayer player);
    IState Copy();

    List<MoveStateCombinaison> GetPossibleStates(IPlayer player);
  }
}