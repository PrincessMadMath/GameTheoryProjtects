using System;
using System.Collections.Generic;
using GameComponent.GameElement;
using GameComponent.Interface;
using GameSolver.Component;
using TicTacToe.Player;

namespace TicTacToe.TicTacToeGameElement
{
  public class TicTacTocState : IState
  {
    private GameBoard _gameBoard;

    private int? _winningTeam;

    private bool _isGameOver = false;

    public TicTacTocState(int size)
    {
      _gameBoard = new GameBoard(size, size);
    }

    public bool PlayMove(TicTacToeMove move)
    {
      return _gameBoard.TryAddToken(move.X, move.Y, move.Token);
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

    public List<MoveStateCombinaison> GetPossibleStates(IPlayer player)
    {
      ITicTacToePlayer tttPlayer = player as ITicTacToePlayer;
      if (tttPlayer == null)
      {
        throw new ArgumentException("Receive a not TicTacToePlayer");
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
              NextState = accessibleState
            });
          }
        }
      }

      return list;
    }

    public int GetValueFor(IPlayer player)
    {
      if (_winningTeam == null)
      {
        return 0;
      }

      return player.Team == _winningTeam ? 1 : -1;
    }

    public IState Copy()
    {
      var copy = new TicTacTocState(_gameBoard.BoardHeight);
      for (int i = 0; i < _gameBoard.BoardHeight; i++)
      {
        for (int j = 0; j < _gameBoard.BoardWidth; j++)
        {
          copy._gameBoard.TryAddToken(i, j, _gameBoard.GetToken(i, j));
        }
      }
      return copy;
    }

    public void Display()
    {
      _gameBoard.Display();
    }

  }
}