using System;
using Newtonsoft.Json;

namespace TicTacToe.Utils
{
  public static class Utils
  {
    public static string PadBoth(this string str, int length)
    {
      int spaces = length - str.Length;
      int padLeft = spaces/2 + str.Length;
      return str.PadLeft(padLeft).PadRight(length);
    }

    public static int GetIntFromConsole(string message)
    {
      bool hadEnterInteger;
      int returnValue;

      do
      {      
        Console.WriteLine(message);
        string input = Console.ReadLine();
        hadEnterInteger = int.TryParse(input, out returnValue);
      } while (!hadEnterInteger);
      return returnValue;
    }

  }
}