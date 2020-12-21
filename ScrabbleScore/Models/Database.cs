using System;
using MySql.Data.MySqlClient;
using ScrabbleScore;

namespace ScrabbleScore.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}