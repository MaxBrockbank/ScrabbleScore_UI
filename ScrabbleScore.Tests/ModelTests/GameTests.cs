using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ScrabbleScore.Models;

namespace ScrabbleScore.Tests
{
  [TestClass]
  public class GameTests : IDisposable
  {
    public void Dispose()
    {

    }

    [TestMethod]
    public void GameConstructor_NewGameObject_Game()
    {
        string userInput = "word";
        Game newWord = new Game(userInput);
        Assert.AreEqual(typeof(Game), newWord.GetType());
    }

    [TestMethod]
    public void GameConstructor_CreatesCharacterArrayFromInput_Array()
    {
        string userInput = "word";
        Game newWord = new Game(userInput);
        Assert.AreEqual(typeof(char[]), newWord.ArrayForWord.GetType());
    }

    [TestMethod]
    public void PlayerScore_CalculateScore_Int()
    {
        string userInput = "word";
        Game newWord = new Game(userInput);
        Assert.AreEqual(8, newWord.PlayerScore());
    }

    [TestMethod]
    public void PlayerScore_CalculateScore2Points_int()
    {
        string userInput = "dog";
        Game newWord = new Game(userInput);
        Assert.AreEqual(5, newWord.PlayerScore());
    }
  }
}