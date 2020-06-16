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
            var game = new Game(grid);
            Console.WriteLine(grid.Display());
            game.Run();
        }

        private static Grid SetUpGrid(int gridRows, int gridColumns, InputParser userInputParser)
        {
            var grid = new Grid(gridRows, gridColumns);
            grid.AddCellsToLocations();
            var locationList = new List<int[]>();
            var startingLiveCellLocations = GetStartingLiveCellLocations(userInputParser, locationList, gridRows, gridColumns);
            SetStartingCellStatesToLive(startingLiveCellLocations, grid);
            return grid;
        }

        private static void SetStartingCellStatesToLive(IEnumerable<int[]> startingLocations, IGrid grid)
        {
            foreach (var coordinate in startingLocations)
            {
                var location = grid.GetLocationAt(coordinate[0], coordinate[1]);
                location.ChangeCellStateTo(State.Alive);
            }
        }

        private static IEnumerable<int[]> GetStartingLiveCellLocations(InputParser userInputParser, List<int[]> startingLocations, int gridRows, int gridColumns)
        {
            var startingLocation = userInputParser.GetStartingLiveLocation(gridRows, gridColumns);
            startingLocations.Add(startingLocation);
            var getMoreLocations = userInputParser.GetAdditionalLocations();
            return !getMoreLocations ? startingLocations : GetStartingLiveCellLocations(userInputParser, startingLocations, gridRows, gridColumns);
        }

    }
}