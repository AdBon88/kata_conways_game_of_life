using System;
using System.Threading;

namespace kata_conways_game_of_life
{
    public class Game
    {
        private readonly InputParser _inputParser;
        private readonly IGrid _grid;

        public Game(InputParser inputParser, IGrid grid)
        {
            _inputParser = inputParser;
            _grid = grid;
        }


        public void Run()
        {
            Thread.Sleep(500);
            var nextLocationsWithCellDeath = _grid.GetLocationsToKillCells();
            var nextLocationsToReviveCells = _grid.GetLocationsToReviveCells();
            if (_grid.WillAllCellsDieNext()) return;
            foreach (var location in nextLocationsWithCellDeath)
            {
                location.ChangeCellStateTo(State.Dead);
            }

            foreach (var location in nextLocationsToReviveCells)
            {
                location.ChangeCellStateTo(State.Alive);
            }
            Console.Clear();
            Console.WriteLine(_grid.Display());
            
        }
    }
}