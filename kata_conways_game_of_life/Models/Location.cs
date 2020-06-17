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
        private ICell _cell;
        public State NextCellState { get; private set; }

        public void AddCell(ICell cell)
        {
           _cell = cell;
        }
        
        public void SetNextCellState(int liveNeighboursCount)
        {
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