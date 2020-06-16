using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace kata_conways_game_of_life
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInputParser = new InputParser(new Prompt());
            var gridRows = userInputParser.ParseGridDimension("rows");
            var gridColumns = userInputParser.ParseGridDimension("columns");
            var grid = SetUpGrid(gridRows, gridColumns, userInputParser);
            Console.Clear();
            Console.WriteLine(grid.Display());
            GetStartingLiveCellLocations(userInputParser, gridRows, gridColumns, grid);
            var game = new Game(grid);
            game.Run();
        }

        private static Grid SetUpGrid(int gridRows, int gridColumns, InputParser userInputParser)
        {
            var grid = new Grid(gridRows, gridColumns);
            grid.AddCellsToLocations();
            return grid;
        }
        
        private static IGrid GetStartingLiveCellLocations(InputParser userInputParser, int gridRows, int gridColumns, IGrid grid)
        {
            var startingLocation = userInputParser.GetStartingLiveLocation(gridRows, gridColumns);
            var targetLocation = grid.GetLocationAt(startingLocation[0], startingLocation[1]);
            targetLocation.ChangeCellStateTo(State.Alive);
            Console.Clear();
            Console.WriteLine(grid.Display());
            var getMoreLocations = userInputParser.GetAdditionalLocations();
            return !getMoreLocations ? grid : GetStartingLiveCellLocations(userInputParser, gridRows, gridColumns, grid);
        }

    }
}