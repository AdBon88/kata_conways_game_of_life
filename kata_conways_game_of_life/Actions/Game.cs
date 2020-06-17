using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using kata_conways_game_of_life.Models;

namespace kata_conways_game_of_life.Actions
{
    public class Game
    {
        private readonly IGrid _grid;

        public Game(IGrid grid) //todo: receive game set up class as parameter
        {
            _grid = grid;
        }
        
        public void Run() //TODO: rename this
        {
            do
            {
                Thread.Sleep(1000);
                _grid.SetNextCellStateForAllLocations();
                var nextLocationsWithCellDeath = _grid.GetLocationsToKillCells() ;
                var nextLocationsToReviveCells = _grid.GetLocationsToReviveCells();
                if (nextLocationsWithCellDeath.Any())
                {
                    ChangeCellStateAtLocations(nextLocationsWithCellDeath, State.Dead);
                }

                if (nextLocationsToReviveCells.Any())
                {
                    ChangeCellStateAtLocations(nextLocationsToReviveCells, State.Alive);
                }

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
