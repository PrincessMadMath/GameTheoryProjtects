using System;
using GameComponent.Interface;
using GameSolver.Algo;
using GameSolver.Component;

namespace GameComponent.GameElement
{
    public class IAPlayer : IPlayer
    {
        public int Team { get; set; }
        public IToken Token { get; set; }
        public Strateger Strateger { get; set; }

        public IAPlayer(IToken token, int team)
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
            if (!(tttGame.State is IResolvableState))
            {
                throw new ArgumentException("The state is not a resolvable state");
            }

            ITeamIdentifier opponentPlayer = tttGame.PlayerA == this ? tttGame.PlayerB : tttGame.PlayerA;

            var bestMove = Strateger.FindBestMove(tttGame.State as IResolvableState, this, opponentPlayer);
            return bestMove;
        }
    }
}