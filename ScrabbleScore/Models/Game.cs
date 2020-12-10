using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ScrabbleScore.Models
{
  public class Game
  {
    public char[] ArrayForWord {get; set;}
    public string UserWord {get; set;}
    public int UserScore {get; set;}
    private static string onePointPattern = @"[aeioulnrst]";
    public Regex onePoint = new Regex(onePointPattern, RegexOptions.IgnoreCase);

    public Game (string word)
    {
      UserScore = 0;
      UserWord = word;
      ArrayForWord = word.ToCharArray();
    }

    public int PlayerScore()
    {
      foreach (char element in ArrayForWord)
      {
        
        if (onePoint.IsMatch(element.ToString()))
        {
            UserScore += 1;
        }
        else
        {
            UserScore += 0;
        }
      }
      return UserScore;      
    }

  }
}