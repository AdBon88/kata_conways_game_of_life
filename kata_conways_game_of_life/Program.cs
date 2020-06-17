using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using kata_conways_game_of_life.Actions;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;

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

        private static IGrid SetUpGrid(int gridRows, int gridColumns, InputParser userInputParser) //TODO: move this to a different class (e.g. game set up)
        {
            IGrid grid = new Grid(gridRows, gridColumns);
            grid.AddCellsToLocations();
            return grid;
        }
        
        private static IGrid GetStartingLiveCellLocations(InputParser userInputParser, int gridRows, int gridColumns, IGrid grid) //TODO: move this to a different class (e.g. game set up)
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