using System;
using System.Collections.Generic;
using System.Threading;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;

namespace kata_conways_game_of_life.Actions
{
    public class Game
    {
        private readonly Grid _grid;
        private readonly InputParser _inputParser;

        public Game(Grid grid, InputParser inputParser)
        {
            _grid = grid;
            _inputParser = inputParser;
        }

        public void SetUpStartingGrid()
        {
            bool isAddingLocation;
            do
            {
                var startingLocation = _inputParser.GetStartingLiveLocation(_grid.NumberOfRows, _grid.NumberOfColumns);
                var rowNumber = startingLocation[0];
                var columnNumber = startingLocation[1];
                var targetLocation = _grid.GetLocationAt(rowNumber, columnNumber);
                targetLocation.ChangeCellStateTo(State.Alive);
                _grid.SetNextCellStateForAllLocations();
                DisplayGrid();
                isAddingLocation = _inputParser.IsAddingLocation();
                
            } while (isAddingLocation);
        }
        public void UpdateGridAtEachTick()
        {
            do
            {
                Thread.Sleep(1000);
                
                var nextLocationsWithCellDeath = _grid.GetLocationsToKillCells();
                ChangeCellStateAtLocations(nextLocationsWithCellDeath, State.Dead);
                
                var nextLocationsToReviveCells = _grid.GetLocationsToReviveCells();
                ChangeCellStateAtLocations(nextLocationsToReviveCells, State.Alive);
                
                _grid.SetNextCellStateForAllLocations();
                
                DisplayGrid();

            } while (_grid.HasLiveCells() && _grid.ConfigurationIsChanging());
        }
        
        private static void ChangeCellStateAtLocations(IEnumerable<ILocation> locationsToChangeCellState, State state)
        {
            foreach (var location in locationsToChangeCellState)
            {
                location.ChangeCellStateTo(state);
            }
        }
        
        private void DisplayGrid()
        {
            Console.Clear();
            Console.WriteLine(_grid.GetFormattedGrid());
            Console.WriteLine(Environment.NewLine);
        }
    }
}
