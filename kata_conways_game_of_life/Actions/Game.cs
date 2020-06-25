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
        private readonly IInput _input;

        public Game(Grid grid, IInput input)
        {
            _grid = grid;
            _input = input;
        }

        public void SetInitialLiveCells()
        {
            string input;
            do
            {
                Output.DisplayString(Prompts.StartingLocation);
                input = _input.ReadInput();
                if (string.IsNullOrWhiteSpace(input)) continue;
                int[] coordinates;
                try
                { 
                    coordinates = InputParser.ParseInputCoordinates(input);
                    Validator.ValidateCoordinates(coordinates, _grid.NumberOfRows, _grid.NumberOfColumns);
                }
                catch (Exception e)
                {
                    Output.ErrorMessage(e.Message);
                    continue;
                }
                MakeCellLiveAt(coordinates);
                _grid.SetNextCellStateForAllLocations();
                Console.Clear();
                Output.DisplayString(_grid.GetFormattedString());
                
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
                Console.Clear();
                Output.DisplayString(_grid.GetFormattedString());

            } while (_grid.HasLiveCells() && _grid.ConfigurationIsChanging());
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
