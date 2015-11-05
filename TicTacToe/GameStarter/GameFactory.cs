using Connect4.GameElement;
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

                    IPlayer humanPlayer = PlayerFactory.GetHumanPlayer(GameType.TicTacToe, 0);
                    IPlayer iaPlayer = PlayerFactory.GetAiPlayer(GameType.TicTacToe, 1, 4);
                    var gameBoard = new OptimizeGameBoard(4, 4, humanPlayer.Token, iaPlayer.Token);

                    IState initialState = new TicTacTocState(gameBoard);


                    game = new GameManager2P()
                    {
                        GameState = initialState,
                        PlayerA = humanPlayer,
                        PlayerB = iaPlayer
                    };

                    break;

                case GameType.Connect4:
                    humanPlayer = PlayerFactory.GetHumanPlayer(GameType.Connect4, 0);
                    iaPlayer = PlayerFactory.GetAiPlayer(GameType.Connect4, 1, 6);
                    gameBoard = new OptimizeGameBoard(5, 4, humanPlayer.Token, iaPlayer.Token);

                    initialState = new Connect4State(gameBoard);


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