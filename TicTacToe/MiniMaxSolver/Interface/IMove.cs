using System.Security.Cryptography.X509Certificates;

namespace MiniMax.Interface
{
  /// <summary>
  /// Represent a Move that can be made on a state in a game context
  /// </summary>
  public interface IMove
  {
    /// <summary>
    /// Use for debugging purpose
    /// </summary>
    /// <returns>A description of the move</returns>
    string GetDescription();
  }
}