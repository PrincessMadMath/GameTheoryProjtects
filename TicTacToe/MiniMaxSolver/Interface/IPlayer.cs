using System.ComponentModel;

namespace MiniMax.Interface
{
  /// <summary>
  /// Represent a participant of a game
  /// </summary>
  public interface IPlayer
  {
    int Team { get; set; }
  }
}