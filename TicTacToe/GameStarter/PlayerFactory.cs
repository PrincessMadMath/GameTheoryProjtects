using GameComponent.GameElement;
using GameComponent.Interface;
using GameSolver;
using TicTacToe.Player;


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

                case GameFactory.GameType.Connect4:

                    player = new Connect4.Player.HumanPlayer(new Token(team, 'X'), team);

                    break;
            }

            return player;
        }

        public static IPlayer GetAiPlayer(GameFactory.GameType gameType, int team, int depth)
        {
            IPlayer player = null;

            player = new IAPlayer(new Token(team, 'O'), team)
            {
                Strateger = StrategyResolver.GetStrateger(depth)
            };

            return player;
        }
    }
}