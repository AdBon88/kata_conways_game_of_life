using System.Collections;
using System.Collections.Generic;
using System.Linq;


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
        private ICell _cell;

        public void AddCell(ICell cell)
        {
           _cell = cell;
        }
        
        public State GetNextCellState(int liveNeighboursCount)
        {
            if (liveNeighboursCount == 3) return State.Alive;
            
            if (_cell.State == State.Alive && liveNeighboursCount == 2) return State.Alive;
            
            return State.Dead;
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
            return _cell.GetDisplay();
        }

        public State GetCellState()
        {
            return _cell.State;
        }
        
    }
}