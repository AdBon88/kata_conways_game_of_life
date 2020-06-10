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
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
            Cell = cell;
        }
        
        public int RowNumber { get; }
        public int ColumnNumber { get; }
        public Cell Cell { get; }



        public State GetNextCellState(IEnumerable<Cell> neighbours)
        {
            var liveNeighbours = neighbours.Count(neighbour => neighbour.State == State.Alive);

            if (liveNeighbours == 3) return State.Alive;
            
            if (Cell.State == State.Alive && liveNeighbours == 2) return State.Alive;
            
            return State.Dead;

        }
        
    }
}