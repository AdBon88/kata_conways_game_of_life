using System;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;

namespace kata_conways_game_of_life.Actions
{
    public class GameSetUp
    {
        
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