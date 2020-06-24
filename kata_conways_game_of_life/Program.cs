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
            var inputParser = new InputParser(input);
            var numberOfRows = inputParser.ParseGridDimension("rows");
            var numberOfColumns = inputParser.ParseGridDimension("columns");
            var grid = new Grid(numberOfRows, numberOfColumns);
            grid.SetNeighboursForAllLocations();
            grid.AddDeadCellsToAllLocations();
            Console.Clear();
            Console.WriteLine(grid.GetFormattedString());
            var game = new Game(grid, inputParser, input);
            game.SetUpStartingGrid();
            game.UpdateGridAtEachTick();
        }

    }
    
    //TODO: extract main function into smaller components
    //TODO: make a display grid method in output
    //TODO: make resex file
    //TODO: make output class
}