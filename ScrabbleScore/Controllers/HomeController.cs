using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ScrabbleScore.Models;

namespace ScrabbleScore.Controllers
{
  public class HomeController : Controller
  {
    [Route ("/")]
    public ActionResult GameStart(){return View();}

    [Route("/gameResult")]
    public ActionResult GameResult(string userInput)
    {
      Game newGame = new Game(userInput);
      newGame.PlayerScore();
      newGame.Response = $"Your word {newGame.UserWord} is equal to {newGame.UserScore} points.";
      return View(newGame);
    }
    
  }
}