using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace kata_conways_game_of_life
{
    public class Location
    {
        public Location(int rowNumber, int columnNumber, Cell cell)
        {
            _rowNumber = rowNumber;
            _columnNumber = columnNumber;
            _cell = cell;
        }
        
        private readonly int _rowNumber;
        private readonly int _columnNumber;
        private readonly Cell _cell;
        public IEnumerable<Cell> Neighbours { get; set; }


        public State GetNextCellState()
        {
            var liveNeighbours = Neighbours.Count(n => n.State == State.Alive);
            State nextState;
            if (liveNeighbours == 3) 
            {
                nextState = State.Alive;
            }
            else if (_cell.State == State.Alive && liveNeighbours == 2)
            {
                nextState = State.Alive;
            }
            else
            {
                nextState = State.Dead;
            }

            return nextState;

        }
        
    }
}