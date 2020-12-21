using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace ScrabbleScore.Models
{
  public class Game
  {
    public char[] ArrayForWord {get; set;}
    public string UserWord {get; set;}
    public int UserScore {get; set;}
    public int Id {get; set;}
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

    public Game (string word, int userScore, int id)
    {
      UserScore = userScore;
      UserWord = word;
      Id = id;
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

    // public override bool Equals(System.Object otherGame)
    // {
    //   if(!(otherGame is Game))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Game newGame = (Game) otherGame;
    //     bool idEquality = (this.Id == newGame.Id);
    //     bool wordEquality = (this.UserWord == newGame.UserWord);
    //     bool scoreEquality = (this.UserScore == newGame.UserScore);
    //     return (idEquality && wordEquality && scoreEquality);
    //   }
    // }

    public static List<Game> GetAll()
    {
      List<Game> allWords = new List<Game> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM words;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int wordId = rdr.GetInt32(2);
        string userWord = rdr.GetString(0);
        int userScore = rdr.GetInt32(1);
        Game newGame = new Game(userWord, userScore, wordId);
        allWords.Add(newGame);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allWords;

    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

      cmd.CommandText = @"INSERT INTO words (word, score) VALUES (@TheWord, @WordScore);";
      MySqlParameter word = new MySqlParameter();
      MySqlParameter score = new MySqlParameter();
      word.ParameterName = "@TheWord";
      word.Value = this.UserWord;
      score.ParameterName = "@WordScore";
      score.Value = this.UserScore;
      cmd.Parameters.Add(word);
      cmd.Parameters.Add(score);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;

      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM words";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Game> Find(int searchScore)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM words WHERE score >= @WordScore";

      MySqlParameter score = new MySqlParameter();
      score.ParameterName = "@WordScore";
      score.Value = searchScore;
      cmd.Parameters.Add(score);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Game> wordsOfScore = new List<Game>{};
      while(rdr.Read())
      {
        int id = (int) rdr.GetInt32(2);
        int wordScore = rdr.GetInt32(1);
        string word = rdr.GetString(0);
        Game newGame = new Game(word, wordScore, id);
        wordsOfScore.Add(newGame);
      }
      return wordsOfScore;

    }
  }
}