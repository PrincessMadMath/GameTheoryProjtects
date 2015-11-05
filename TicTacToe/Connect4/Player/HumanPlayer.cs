using System;
using Connect4.GameElement;
using GameComponent.GameElement;
using GameComponent.Interface;
using GameSolver.Component;

namespace Connect4.Player
{
    public class HumanPlayer : IPlayer
    {
        public int Team { get; set; }
        public IToken Token { get; set; }

        public HumanPlayer(IToken token, int team)
        {
            Token = token;
            Team = team;
        }

        public IMove GetMove(IGameInfo game)
        {
            GameInfo2P tttGame = game as GameInfo2P;
            if (tttGame == null)
            {
                throw new ArgumentException("The game is not a 2 player game info");
            }

            int x = GameComponent.Utils.Utils.GetIntFromConsole("Entrer valeur de x:");
            return new Connect4Move()
            {
                Token = Token,
                X = x,
            };
        }
    }
}