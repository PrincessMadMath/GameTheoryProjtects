
namespace GameComponent.Interface
{
  public interface IToken
  {
    int Team { get; set; }
    char GetDisplayValue();
  }
}