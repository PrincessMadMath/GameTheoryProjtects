using GameComponent.GameElement;
using GameComponent.Interface;

namespace TicTacToe.Test
{
    public class OptimizeBoardTest : BoardBaseTest
    {
        public override IGameBoard GetBoard(int width, int height, IToken playerA, IToken playerB)
        {
            return  new OptimizeGameBoard(width, height, playerA, playerB);
        }
    }
}