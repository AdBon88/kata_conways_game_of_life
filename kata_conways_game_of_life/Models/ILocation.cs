namespace kata_conways_game_of_life.Models
{
    public interface ILocation
    {
        public int RowNumber { get; }
        public int ColumnNumber { get; }
        State NextCellState { get; }
        void AddCell(ICell cell);
        State GetCellState();
        void SetNextCellState(int liveNeighboursCount);
        void ChangeCellStateTo(State newState);
        string GetDisplay();

    }
}