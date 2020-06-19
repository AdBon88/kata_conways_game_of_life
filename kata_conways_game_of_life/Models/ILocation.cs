using System.Collections.Generic;

namespace kata_conways_game_of_life.Models
{
    public interface ILocation
    {
        public int RowNumber { get; }
        public int ColumnNumber { get; }
        State NextCellState { get; }
        void AddCell(ICell cell);
        void SetNeighbours(IEnumerable<ILocation> neighbours);
        State GetCellState();
        void SetNextCellState();
        void ChangeCellStateTo(State newState);
        string GetDisplay();

    }
}