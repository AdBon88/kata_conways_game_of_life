using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;

namespace kata_conways_game_of_life.Actions
{
    public class Game
    {
        private readonly IGrid _grid;
        private readonly InputParser _inputParser;

        public Game(IGrid grid, InputParser inputParser)
        {
            _grid = grid;
            _inputParser = inputParser;
        }

        public IGrid GetStartingLiveCellLocations()
        {
            var startingLocation = _inputParser.GetStartingLiveLocation(_grid.NumberOfRows, _grid.NumberOfColumns);
            var rowNumber = startingLocation[0];
            var columnNumber = startingLocation[1];
            var targetLocation = _grid.GetLocationAt(rowNumber, columnNumber);
            targetLocation.ChangeCellStateTo(State.Alive);
            Console.Clear();
            Console.WriteLine(_grid.Display());
            var getMoreLocations = _inputParser.GetAdditionalLocations();
            return !getMoreLocations ? _grid : GetStartingLiveCellLocations();
        }
        
        public void UpdateGridAtEachTick()
        {
            do
            {
                Thread.Sleep(1000);
                
                _grid.SetNextCellStateForAllLocations();
                if (_grid.IsConfigurationInfinite()) break;
                
                var nextLocationsWithCellDeath = _grid.GetLocationsToKillCells();
                ChangeCellStateAtLocations(nextLocationsWithCellDeath, State.Dead);
                
                var nextLocationsToReviveCells = _grid.GetLocationsToReviveCells();
                ChangeCellStateAtLocations(nextLocationsToReviveCells, State.Alive);

                Console.Clear();
                Console.WriteLine(_grid.Display());
                
            } while (!_grid.AreAllCellsDead());

        }

        private static void ChangeCellStateAtLocations(IEnumerable<ILocation> locationsToChangeCellState, State state)
        {
            foreach (var location in locationsToChangeCellState)
            {
                location.ChangeCellStateTo(state);
            }
        }
    }
}
