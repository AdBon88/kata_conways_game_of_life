using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kata_conways_game_of_life.Models
{
    public class Grid : IGrid
    {
        public Grid(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            _locations = GenerateGrid();
        }
        
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        private readonly IEnumerable<ILocation> _locations;
        private const int startingRowNumber = 1;
        private const int startingColumnNumber = 1;
        
        
        public void AddCellsToLocations()
        {
            foreach (var location in _locations)
            {
                location.AddCell(new Cell());
            }
        }

        public string Display()
        {
            var gridDisplay = new StringBuilder();
            for (var rowNumber = startingRowNumber; rowNumber <= NumberOfRows; rowNumber++)
            {
                var locationsInRow = _locations.Where(location => location.RowNumber == rowNumber);
                foreach (var location in locationsInRow)
                {
                    gridDisplay.Append(location.GetDisplay());
                }

                gridDisplay.AppendLine();
            }
            return gridDisplay.ToString();
        }
        
        public ILocation GetLocationAt(int rowNumber, int columnNumber)
        {
            return _locations.FirstOrDefault(location =>
                location.RowNumber == rowNumber && location.ColumnNumber == columnNumber);
        }

        public void SetNextCellStateForAllLocations()
        {
            foreach (var location in _locations)
            {
                var liveNeighboursCount = GetLiveNeighboursCountFor(location);
                location.SetNextCellState(liveNeighboursCount);
            }
        }
        public IEnumerable<ILocation> GetLocationsToKillCells()
        {
            var cellDeathLocations = _locations.Where(l =>
                l.GetCellState() == State.Alive &&
                l.NextCellState == State.Dead);
            return cellDeathLocations;
        }

        public IEnumerable<ILocation> GetLocationsToReviveCells()
        {
            var cellReviveLocations = _locations.Where(l =>
                l.GetCellState() == State.Dead &&
                l.NextCellState == State.Alive);
            return cellReviveLocations;
        }
        public bool AreAllCellsDead()
        {
            return _locations.All(location =>
                location.GetCellState() == State.Dead);
        }
        
        private IEnumerable<ILocation> GenerateGrid()
        {
            var gridLocations = new List<ILocation>();
            for (var i = startingRowNumber; i <= NumberOfRows; i++)
            {
                for (var j = startingColumnNumber; j <= NumberOfColumns; j++)
                {
                    gridLocations.Add(new Location(i, j));
                }
            }

            return gridLocations;
        }
        private int GetLiveNeighboursCountFor(ILocation location)
        {
            var neighbours = GetNeighboursFor(location);
            return neighbours.Count(neighbour => neighbour.GetCellState() == State.Alive);
        }

        private IEnumerable<ILocation> GetNeighboursFor(ILocation location)
        {
            var row = location.RowNumber;
            var column = location.ColumnNumber;
            var leftColumn = column == startingColumnNumber ? NumberOfColumns : column - 1;
            var rightColumn = column == NumberOfColumns ?  startingColumnNumber : column + 1;
            var aboveRow = row == startingRowNumber ? NumberOfRows : row - 1;
            var belowRow = row == NumberOfRows ? startingRowNumber : row + 1;
            return new List<ILocation>()
            {
                GetLocationAt(aboveRow, leftColumn),
                GetLocationAt(aboveRow, column),
                GetLocationAt(aboveRow, rightColumn),
                GetLocationAt(row, leftColumn),
                GetLocationAt(row, rightColumn),
                GetLocationAt(belowRow, leftColumn),
                GetLocationAt(belowRow, column),
                GetLocationAt(belowRow, rightColumn)
            };
        }
    }
}