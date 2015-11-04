using System;
using GameComponent.GameElement;
using GameComponent.Interface;
using GameSolver.Component;
using TicTacToe.TicTacToeGameElement;

namespace TicTacToe.Player
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
            int y = GameComponent.Utils.Utils.GetIntFromConsole("Entrer valeur de y:");
            return new TicTacToeMove()
            {
                Token = Token,
                X = x,
                Y = y
            };
        }
    }
}