using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ScrabbleScore.Models
{
  public class Game
  {
    public char[] ArrayForWord {get; set;}
    public string UserWord {get; set;}
    private static string onePointPattern = @"aeioulnrst";
    public Regex onePoint = new Regex(onePointPattern, RegexOptions.IgnoreCase);

    public Game (string word)
    {
      UserWord = word;
      ArrayForWord = word.ToCharArray();
    }

    public int PlayerScore()
    {
      return 0;
    }

  }
}