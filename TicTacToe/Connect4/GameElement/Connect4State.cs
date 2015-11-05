using System;
using System.Collections.Generic;
using GameComponent.GameElement;
using GameComponent.Interface;
using GameComponent.Utils;
using GameSolver.Component;

namespace Connect4.GameElement
{
    public class Connect4State : IResolvableState, IState
    {
        private IGameBoard _gameBoard;
        private int? _winningTeam;
        private bool _isGameOver = false;

        public Connect4State(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public Connect4State(int width, int height, IToken player1, IToken player2)
        {
            _gameBoard = new OptimizeGameBoard(width, height, player1, player2);
        }

        public bool PlayMove(IMove move)
        {
            Connect4Move c4Move = move as Connect4Move;
            if (c4Move == null)
            {
                throw new ArgumentException("Move is not a Connect4Move");
            }

            int freePosition = -1;
            for (int i = 0; i < _gameBoard.BoardHeight; i++)
            {
                if (_gameBoard.GetToken(c4Move.X, i) == null)
                {
                    freePosition = i;
                    break;
                }
            }

            return _gameBoard.TryAddToken(c4Move.X, freePosition, c4Move.Token);
        }

        public bool IsGameOver()
        {
            if (!_isGameOver)
            {
                CheckIfGameOver();
            }
            return _isGameOver;
        }

        private void CheckIfGameOver()
        {
            var optimizeBoard = _gameBoard as IGameOverDetector;

            _winningTeam = optimizeBoard.GetWinningTeam();

            if (_winningTeam != null)
            {
                _isGameOver = true;
            }
            else
            {
                _isGameOver = CheckIfNull();
            }
        }

        private bool CheckIfNull()
        {
            for (int i = 0; i < _gameBoard.BoardWidth; i++)
            {
                if (_gameBoard.GetToken(i, _gameBoard.BoardHeight -1) == null)
                {
                    return false;
                }
            }
            return true;
        }

        public void Display()
        {
            BoardDisplayer.Display(_gameBoard);
        }

        public int GetValueFor(ITeamIdentifier player)
        {
            if (_winningTeam == null)
            {
                return 0;
            }

            return player.Team == _winningTeam ? 1 : -1;
        }

        public IResolvableState Copy()
        {
            var copy = _gameBoard.Copy();
            return new Connect4State(copy);
        }

        public List<MoveStateCombinaison> GetPossibleStates(ITeamIdentifier player)
        {
            IPlayer tttPlayer = player as IPlayer;
            if (tttPlayer == null)
            {
                throw new ArgumentException("Not a team player");
            }

            List<MoveStateCombinaison> list = new List<MoveStateCombinaison>();

            for (int i = 0; i < _gameBoard.BoardWidth; i++)
            {
                for (int j = 0; j < _gameBoard.BoardHeight; j++)
                {
                    if (_gameBoard.GetToken(i, j) == null)
                    {
                        var accessibleState = Copy() as Connect4State;
                        var possibleMove = new Connect4Move()
                        {
                            X = i,
                            Token = tttPlayer.Token
                        };
                        accessibleState.PlayMove(possibleMove);
                        list.Add(new MoveStateCombinaison()
                        {
                            Move = possibleMove,
                            NextResolvableState = accessibleState
                        });
                        break;
                    }
                }
            }
            return list;
        }
    }
}