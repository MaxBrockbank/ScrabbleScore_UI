using System;
using System.Collections.Generic;


namespace ScrabbleScore.Models
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Scrabble Score Calculator");
            Console.WriteLine("Please enter a word");
            string userInput = Console.ReadLine();
            Game newGame = new Game(userInput);
            Console.WriteLine(newGame.PlayerScore());

        }
    }
}