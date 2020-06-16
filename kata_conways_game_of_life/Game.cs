using System;
using System.Linq;
using System.Threading;

namespace kata_conways_game_of_life
{
    public class Game
    {
        private readonly IGrid _grid;

        public Game(IGrid grid)
        {
            _grid = grid;
        }


        public void Run()
        {
            while (true)
            {
                Thread.Sleep(500);
                var nextLocationsWithCellDeath = _grid.GetLocationsToKillCells();
                var nextLocationsToReviveCells = _grid.GetLocationsToReviveCells();
                if (nextLocationsWithCellDeath.Any())
                {
                    foreach (var location in nextLocationsWithCellDeath)
                    {
                        location.ChangeCellStateTo(State.Dead);
                    }
                    
                }
                if (nextLocationsToReviveCells.Any())
                {
                    foreach (var location in nextLocationsToReviveCells)
                    {
                        location.ChangeCellStateTo(State.Alive);
                    }
                    
                }
                
                Console.Clear();
                Console.WriteLine(_grid.Display());
                if (_grid.AreAllCellsDead()) return;
            }
        }
    }
}