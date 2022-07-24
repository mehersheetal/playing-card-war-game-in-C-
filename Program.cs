using System;

namespace CardGame
{
    class CardGameWar
    {
        static void Main(string[] args)
        {
            

            for (int i = 0; i < 1000; i++)
            {
                Console.Title = "WARGame";
               
                Console.WriteLine("Welcome to War Game");

                //Create game
                Game game = new Game("PRAVIN", "SHEETAL", "TANUSH");
                DateTime start = DateTime.Now;
                while (!game.IsEndOfGame())
                {
                    game.PlayTurn();
                    DateTime end = DateTime.Now;
                    var executionTime = end.Subtract(start).TotalSeconds;

                    if (executionTime > 30)
                    {
                        Console.WriteLine("Game took more than 30 Sec to Complete !!!");
                        break;
                    }
                }
                Console.Write("Do you want to play again Y/N :  ");
                String yOrN =  Console.ReadLine();
                if (yOrN.Equals("N") || yOrN.Equals("n"))
                {
                    break;
                }
            }
        }
    }
}