using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace kata_conways_game_of_life
{
    public class Location
    {
        public Location(int rowNumber, int columnNumber)
        {
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }
        
        public int RowNumber { get; }
        public int ColumnNumber { get; }
        private Cell _cell;

        public void SetCell(Cell cell)
        {
           _cell = cell;
        }
        
        public State GetNextCellState(IEnumerable<Cell> neighbours)
        {
            var liveNeighbours = neighbours.Count(neighbour => neighbour.State == State.Alive);

            if (liveNeighbours == 3) return State.Alive;
            
            if (_cell.State == State.Alive && liveNeighbours == 2) return State.Alive;
            
            return State.Dead;

        }

        public State ChangeCellStateTo(State newState)
        {
            return _cell.State = newState;
        }

        public string GetDisplay()
        {
            return _cell.GetDisplay();
        }
        
    }
}