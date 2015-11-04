using System;
using GameComponent.Interface;

namespace GameComponent.GameElement
{
    public class GameManager2P : IGame
    {
        public IState GameState { get; set; }
        public IPlayer PlayerA { get; set; }
        public IPlayer PlayerB { get; set; }

        public void Play()
        {
            IPlayer currentPlayer = PlayerA;

            while (!GameState.IsGameOver())
            {
                GameState.Display();
                bool isMoveValid = false;
                do
                {
                    var move = currentPlayer.GetMove(new GameInfo2P()
                    {
                        PlayerA = PlayerA,
                        PlayerB = PlayerB,
                        State = GameState
                    });
                    isMoveValid = GameState.PlayMove(move);
                } while (!isMoveValid);


                currentPlayer = currentPlayer == PlayerA ? PlayerB : PlayerA;
            }
            Console.WriteLine("\n\n\n*************** Game Over **************");
            GameState.Display();
        }
    }
}