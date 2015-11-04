using System;
using GameComponent.GameElement;
using GameComponent.Interface;
using GameSolver;
using GameSolver.Algo;
using TicTacToe.Player;
using TicTacToe.TicTacToeGameElement;

namespace GameStarter
{
    public static class PlayerFactory
    {
        public static IPlayer GetHumanPlayer(GameFactory.GameType gameType, int team)
        {
            IPlayer player = null;

            switch (gameType)
            {
                case GameFactory.GameType.TicTacToe:

                    player = new HumanPlayer(new Token(team, 'X'), team);

                    break;
            }

            return player;
        }

        public static IPlayer GetAiPlayer(GameFactory.GameType gameType, int team)
        {
            IPlayer player = null;

            player = new IAPlayer(new Token(team, 'O'), team)
            {
                Strateger = StrategyResolver.GetStrateger()
            };

            return player;
        }
    }
}