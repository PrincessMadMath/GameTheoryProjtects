using GameComponent.GameElement;
using GameComponent.Interface;
using TicTacToe.TicTacToeGameElement;

namespace GameStarter
{
    public static class GameFactory
    {
        public enum GameType
        {
            TicTacToe,
            Connect4
        }

        public static IGame GetGame(GameType gameType)
        {
            IGame game = null;

            switch (gameType)
            {
                    case GameType.TicTacToe:
                    IState initialState = new TicTacTocState(3);
                    IPlayer humanPlayer = PlayerFactory.GetHumanPlayer(GameType.TicTacToe, 0);
                    IPlayer iaPlayer = PlayerFactory.GetAiPlayer(GameType.TicTacToe, 1);

                    game = new GameManager2P()
                    {
                        GameState = initialState,
                        PlayerA = humanPlayer,
                        PlayerB = iaPlayer
                    };

                    break;
            }

            return game;
        }
    }
}