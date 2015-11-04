namespace MiniMax.Interface
{
    public interface ISolver
    {
        IMove FindBestMove(IState state, IPlayer player, IPlayer opponentPlayer);
    }
}