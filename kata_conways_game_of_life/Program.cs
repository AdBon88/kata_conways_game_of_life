using System;
using kata_conways_game_of_life.Actions;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;
using Figgle;

namespace kata_conways_game_of_life
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Bubble.Render(Messages.Welcome));
            
            var input = new Input();
            
            var grid = GridSetUp.SetUpGrid(input);

            Console.Clear();
            Output.DisplayString(grid.GetFormattedString());
            
            var game = new Game(grid, input);
            game.SetInitialLiveCells();
            game.UpdateGridAtEachTick();
            
        }


    }
}