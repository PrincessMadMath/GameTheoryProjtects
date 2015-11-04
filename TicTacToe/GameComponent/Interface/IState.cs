using GameSolver.Component;

namespace GameComponent.Interface
{
    public interface IState
    {
        bool PlayMove(IMove move);
        bool IsGameOver();
        void Display();
    }
}