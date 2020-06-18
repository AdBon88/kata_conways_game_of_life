using System;
using kata_conways_game_of_life.Actions;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;

namespace kata_conways_game_of_life
{
    class Program
    {
        static void Main(string[] args)
        {
            var prompt = new Input();
            var userInputParser = new InputParser(prompt);
            var numberOfRows = userInputParser.ParseGridDimension("rows");
            var numberOfColumns = userInputParser.ParseGridDimension("columns");
            IGrid grid = new Grid(numberOfRows, numberOfColumns);
            grid.AddDeadCellsToAllLocations();
            Console.Clear();
            Console.WriteLine(grid.Display());
            var game = new Game(grid, userInputParser);
            game.SetUpStartingGridState();
            game.UpdateGridAtEachTick();
        }

    }
}