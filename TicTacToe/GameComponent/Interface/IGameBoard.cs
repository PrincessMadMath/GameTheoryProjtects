namespace GameComponent.Interface
{
    public interface IGameBoard
    {
        int BoardWidth { get;}
        int BoardHeight { get;}

        IToken GetToken(int x, int y);
        bool TryAddToken(int x, int y, IToken token);
        IGameBoard Copy();
    }
}