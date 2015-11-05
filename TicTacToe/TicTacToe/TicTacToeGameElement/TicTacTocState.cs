using System;
using System.Collections.Generic;
using GameComponent.GameElement;
using GameComponent.Interface;
using GameComponent.Utils;
using GameSolver.Component;

namespace TicTacToe.TicTacToeGameElement
{
    public class TicTacTocState : IResolvableState, IState
    {
        private IGameBoard _gameBoard;

        private int? _winningTeam;

        private bool _isGameOver = false;

        public TicTacTocState(IGameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public TicTacTocState(int size)
        {
            _gameBoard = new GameBoard(size, size);
        }

        public bool PlayMove(IMove move)
        {
            TicTacToeMove tttMove = move as TicTacToeMove;
            if (tttMove == null)
            {
                throw new ArgumentException("Move is not a TicTacToeMove");
            }

            return _gameBoard.TryAddToken(tttMove.X, tttMove.Y, tttMove.Token);
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
            bool hasAWinner = CheckHorizontalWin() || CheckVerticalWin() || CheckDiagonaleWin();
            if (hasAWinner)
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
            for (int i = 0; i < _gameBoard.BoardHeight; i++)
            {
                for (int j = 0; j < _gameBoard.BoardWidth; j++)
                {
                    if (_gameBoard.GetToken(i, j) == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckHorizontalWin()
        {
            for (int j = 0; j < _gameBoard.BoardHeight; j++)
            {
                IToken possibleWinningToken = _gameBoard.GetToken(0, j);
                if (possibleWinningToken == null)
                {
                    continue;
                }
                for (int i = 1; i < _gameBoard.BoardWidth; i++)
                {
                    IToken currentToken = _gameBoard.GetToken(i, j);
                    if (currentToken == null || possibleWinningToken.Team != currentToken.Team)
                    {
                        possibleWinningToken = null;
                        break;
                    }
                }
                if (possibleWinningToken != null)
                {
                    _winningTeam = possibleWinningToken.Team;
                    return true;
                }
            }

            return false;
        }

        private bool CheckVerticalWin()
        {
            for (int i = 0; i < _gameBoard.BoardHeight; i++)
            {
                IToken possibleWinningToken = _gameBoard.GetToken(i, 0);
                if (possibleWinningToken == null)
                {
                    continue;
                }
                for (int j = 1; j < _gameBoard.BoardWidth; j++)
                {
                    IToken currentToken = _gameBoard.GetToken(i, j);
                    if (currentToken == null || possibleWinningToken.Team != currentToken.Team)
                    {
                        possibleWinningToken = null;
                        break;
                    }
                }
                if (possibleWinningToken != null)
                {
                    _winningTeam = possibleWinningToken.Team;
                    return true;
                }
            }

            return false;
        }

        private bool CheckDiagonaleWin()
        {
            if (_gameBoard.BoardHeight != _gameBoard.BoardWidth)
            {
                throw new Exception("Tic-Tac-Toe board is not a square");
            }

            IToken possibleWinningToken = _gameBoard.GetToken(0, 0);
            if (possibleWinningToken != null)
            {
                for (int i = 1; i < _gameBoard.BoardHeight; i++)
                {
                    IToken currentToken = _gameBoard.GetToken(i, i);
                    if (currentToken == null || possibleWinningToken.Team != currentToken.Team)
                    {
                        possibleWinningToken = null;
                        break;
                    }
                }
                if (possibleWinningToken != null)
                {
                    _winningTeam = possibleWinningToken.Team;
                    return true;
                }
            }

            possibleWinningToken = _gameBoard.GetToken(_gameBoard.BoardHeight - 1, 0);
            if (possibleWinningToken != null)
            {
                for (int i = 1; i < _gameBoard.BoardHeight; i++)
                {
                    IToken currentToken = _gameBoard.GetToken(_gameBoard.BoardHeight - 1 - i, i);
                    if (currentToken == null || possibleWinningToken.Team != currentToken.Team)
                    {
                        possibleWinningToken = null;
                        break;
                    }
                }
                if (possibleWinningToken != null)
                {
                    _winningTeam = possibleWinningToken.Team;
                    return true;
                }
            }
            return false;
        }

        public List<MoveStateCombinaison> GetPossibleStates(ITeamIdentifier player)
        {
            IPlayer tttPlayer = player as IPlayer;
            if (tttPlayer == null)
            {
                throw new ArgumentException("Not a team player");
            }

            List<MoveStateCombinaison> list = new List<MoveStateCombinaison>();

            for (int i = 0; i < _gameBoard.BoardHeight; i++)
            {
                for (int j = 0; j < _gameBoard.BoardWidth; j++)
                {
                    if (_gameBoard.GetToken(i, j) == null)
                    {
                        var accessibleState = Copy() as TicTacTocState;
                        var possibleMove = new TicTacToeMove()
                        {
                            X = i,
                            Y = j,
                            Token = tttPlayer.Token
                        };
                        accessibleState.PlayMove(possibleMove);
                        list.Add(new MoveStateCombinaison()
                        {
                            Move = possibleMove,
                            NextResolvableState = accessibleState
                        });
                    }
                }
            }

            return list;
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
            return new TicTacTocState(copy);
        }

        public void Display()
        {
            BoardDisplayer.Display(_gameBoard);
        }

    }
}