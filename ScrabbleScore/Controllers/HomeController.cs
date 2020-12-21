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
      newGame.Save();
      return View(newGame);
    }

    [HttpGet ("/game/show")]
    public ActionResult AllWords()
    {
      List<Game> allWords = Game.GetAll();
      return View(allWords);
    }

    [HttpPost("/game")]
    public ActionResult Delete()
    {
      Game.ClearAll();
      return RedirectToAction("GameStart");
    }

    [HttpGet("/game/search")]
    public ActionResult SearchForm()
    {
      return View();
    }
    
    [HttpPost("/game/search-result")]
    public ActionResult SearchResult(int score)
    {
      List<Game> matches = Game.Find(score);
      return View(matches);
    }
  }
}