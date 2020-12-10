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
    private static string twoPointPattern = @"[dg]";
    private static string threePointPattern = @"[bcmp]";
    private static string fourPointPattern = @"[fhvwy]";
    private static string fivePointPattern = @"[k]";
    private static string eightPointPattern = @"[jx]";
    private static string tenPointPattern = @"[qz]";
    
    public Regex onePoint = new Regex(onePointPattern, RegexOptions.IgnoreCase);
    public Regex twoPoint = new Regex(twoPointPattern, RegexOptions.IgnoreCase);
    public Regex threePoint = new Regex(threePointPattern, RegexOptions.IgnoreCase);
    public Regex fourPoint = new Regex(fourPointPattern, RegexOptions.IgnoreCase);
    public Regex fivePoint = new Regex(fivePointPattern, RegexOptions.IgnoreCase);
    public Regex eightPoint = new Regex(eightPointPattern, RegexOptions.IgnoreCase);
    public Regex tenPoint = new Regex(tenPointPattern, RegexOptions.IgnoreCase);

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
        else if (twoPoint.IsMatch(element.ToString()))
        {
            UserScore += 2;
        }
        else if (threePoint.IsMatch(element.ToString()))
        {
            UserScore += 3;
        }
        else if (fourPoint.IsMatch(element.ToString()))
        {
            UserScore += 4;
        }
        else if (fivePoint.IsMatch(element.ToString()))
        {
            UserScore += 5;
        }
        else if (eightPoint.IsMatch(element.ToString()))
        {
            UserScore += 8;
        }
        else if (tenPoint.IsMatch(element.ToString()))
        {
            UserScore += 10;
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