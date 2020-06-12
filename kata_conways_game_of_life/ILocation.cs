namespace kata_conways_game_of_life
{
    public interface ILocation
    {
        public int RowNumber { get; }
        public int ColumnNumber { get; }
        void AddCell(ICell cell);
        State GetNextCellState(int liveNeighboursCount);
        void ChangeCellStateTo(State newState);
        string GetDisplay();

    }
}