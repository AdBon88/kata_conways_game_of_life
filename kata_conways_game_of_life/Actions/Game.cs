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
        private readonly IInput _input;

        public Game(Grid grid, InputParser inputParser, IInput input)
        {
            _grid = grid;
            _inputParser = inputParser;
            _input = input;
        }

        public void SetUpStartingGrid()
        {
            string input;
            do
            {
                input = _input.GetStartingLiveLocation();
                if (string.IsNullOrWhiteSpace(input)) continue;
                int[] coordinates;
                try
                { 
                    coordinates = _inputParser.ParseInputCoordinates(input);
                    var isLocationInGrid  =
                        Validator.IsLocationInGrid(coordinates, _grid.NumberOfRows, _grid.NumberOfColumns);
                    if (!isLocationInGrid) 
                        throw new ArgumentException(Messages.LocationError);
                    
                }
                catch (Exception e)
                {
                    Output.ErrorMessage(e.Message);
                    continue;
                }
                
                MakeCellLiveAtLocation(coordinates);
                
                _grid.SetNextCellStateForAllLocations();
                
                Output.GridDisplay(_grid.GetFormattedString());
                
            } while (!string.IsNullOrWhiteSpace(input));
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
                
                Output.GridDisplay(_grid.GetFormattedString());

            } while (_grid.HasLiveCells() && _grid.ConfigurationIsChanging());
        }
        
        private void MakeCellLiveAtLocation(int[] coordinates)
        {
            var rowNumber = coordinates[0];
            var columnNumber = coordinates[1];
            var targetLocation = _grid.GetLocationAt(rowNumber, columnNumber);
            targetLocation.ChangeCellStateTo(State.Alive);
        }
        
        private static void ChangeCellStateAtLocations(IEnumerable<Location> locationsToChangeCellState, State state)
        {
            foreach (var location in locationsToChangeCellState)
            {
                location.ChangeCellStateTo(state);
            }
        }

    }
}
