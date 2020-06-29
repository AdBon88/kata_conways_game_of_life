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
        private readonly Grid _grid;
        private readonly IInput _input;

        public Game(Grid grid, IInput input)
        {
            _grid = grid;
            _input = input;
        }

        public void SetInitialLiveCells()
        {
            int[] coordinates;
            do
            {
                coordinates = GetCoordinates();
                if (coordinates is null) continue;
                MakeCellLiveAt(coordinates);
                _grid.SetNextCellStateForAllLocations();
                Console.Clear();
                Output.DisplayString(_grid.GetFormattedString());
                
            } while (coordinates != null);
        }
        
        public void UpdateGridAtEachTick()
        {
            do
            {
                Thread.Sleep(1000);
                var cellDeathLocations = _grid.GetLocationsToKillCells();
                ChangeCellStateAtLocations(cellDeathLocations, State.Dead);
                var liveCellLocations = _grid.GetLocationsToReviveCells();
                ChangeCellStateAtLocations(liveCellLocations, State.Alive);
                _grid.SetNextCellStateForAllLocations();
                Console.Clear();
                Output.DisplayString(_grid.GetFormattedString());

            } while (_grid.HasLiveCells() && _grid.ConfigurationIsChanging());
        }
        
        private int[] GetCoordinates()
        {
            Output.DisplayString(Prompts.StartingLocation);
            var input = _input.ReadInput();
            if (string.IsNullOrWhiteSpace(input))
                return null;
            var validationResult = Validator.ValidateCoordinates(input, _grid.NumberOfRows, _grid.NumberOfColumns);
            if (validationResult.IsValid)
                return validationResult.Coordinates;
            Output.ErrorMessage(validationResult.ErrorMessage);
            return GetCoordinates();
        }
        
        private void MakeCellLiveAt(int[] coordinates)
        {
            var rowNumber = coordinates[0];
            var columnNumber = coordinates[1];
            var targetLocation = _grid.GetLocationAt(rowNumber, columnNumber);
            targetLocation.ChangeCellStateTo(State.Alive);
        }
        
        private static void ChangeCellStateAtLocations(IEnumerable<Location> locations, State state)
        {
            foreach (var location in locations)
            {
                location.ChangeCellStateTo(state);
            }
        }

    }
}
