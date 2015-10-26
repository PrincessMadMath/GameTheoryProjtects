﻿using System;
using System.Collections.Generic;
using MiniMax;
using MiniMax.Interface;
using TicTacToe.Interface;
using TicTacToe.Utils;

namespace TicTacToe.TicTacToeGameElement
{
  public class TicTacTocState : IState
  {
    private GameBoard _gameBoard;

    private int _winningTeam;

    private bool _isGameOver = false;
    public bool IsGameOver
    {
      get
      {
        if (!_isGameOver)
        {
          CheckIfGameOver();
        }
        return _isGameOver;
      }
    }

    public TicTacTocState(int size)
    {
      _gameBoard = new GameBoard(size, size);
    }

    public bool PlayMove(TicTacToeMove move)
    {
      return _gameBoard.TryAddToken(move.X, move.Y, move.Token);
    }

    private void CheckIfGameOver()
    {
      _isGameOver = CheckHorizontalWin() || CheckVerticalWin() || CheckDiagonaleWin();
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

    public List<MoveNextStatePair> GetPossibleStates(IPlayer player)
    {
      ITicTacToePlayer tttPlayer = player as ITicTacToePlayer;
      if (tttPlayer == null)
      {
        throw new ArgumentException("Receive a not TicTacToePlayer");
      }

      List<MoveNextStatePair> list = new List<MoveNextStatePair>();

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
            list.Add(new MoveNextStatePair()
            {
              Move = possibleMove,
              State = accessibleState
            });
          }
        }
      }

      return list;
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

      possibleWinningToken = _gameBoard.GetToken(_gameBoard.BoardHeight - 1, _gameBoard.BoardHeight - 1);
      if (possibleWinningToken != null)
      {
        for (int i = _gameBoard.BoardHeight - 2; i >= 0; i--)
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

      return false;
    }

    public int GetValueFor(IPlayer player)
    {
      if (!IsGameOver)
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