using System.Collections.Generic;
using System.Linq;

namespace kata_conways_game_of_life.Models
{
    public class Location : ILocation
    {
        public Location(int rowNumber, int columnNumber)
        {
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }
        
        public int RowNumber { get; }
        public int ColumnNumber { get; }
        public State NextCellState { get; private set; }
        private ICell _cell;
        private IEnumerable<ILocation> _neighbours;

        public void AddCell(ICell cell)
        {
           _cell = cell;
        }

        public void SetNeighbours(IEnumerable<ILocation> neighbours)
        {
            _neighbours = neighbours;
        }

        public void SetNextCellState()
        {
            var liveNeighboursCount = GetLiveNeighboursCount();
            if (liveNeighboursCount == 3)
            {
                NextCellState = State.Alive;
            }
            else if (_cell.State == State.Alive && liveNeighboursCount == 2)
            {
                NextCellState = State.Alive;
            }
            else
            {
                NextCellState = State.Dead;
            }
        }

        private int GetLiveNeighboursCount()
        {
            return _neighbours.Count(neighbour => neighbour.GetCellState() == State.Alive);
        }

        public void ChangeCellStateTo(State newState)
        {
            if (newState == State.Alive)
            {
                _cell.Revive();
            }
            else
            {
                _cell.Die();
            }
        }

        public string GetDisplay()
        {
            return  _cell.State == State.Dead ? "[ ]" : "[#]";
        }

        public State GetCellState()
        {
            return _cell.State;
        }
        
    }
}