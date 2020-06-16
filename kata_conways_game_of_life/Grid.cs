using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kata_conways_game_of_life
{
    public class Grid : IGrid
    {
        public Grid(int numberOfRows, int numberOfColumns)
        {
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            _locations = GenerateGrid();
        }
        
        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;
        private readonly IEnumerable<ILocation> _locations;
        
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
            for (var rowNumber = 1; rowNumber <= _numberOfRows; rowNumber++)
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

        public int GetLiveNeighboursCountFor(ILocation location)
        {
            var neighbours = GetNeighboursFor(location);
            return neighbours.Count(neighbour => neighbour.GetCellState() == State.Alive);
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
            for (var i = 1; i <= _numberOfRows; i++)
            {
                for (var j = 1; j <= _numberOfColumns; j++)
                {
                    gridLocations.Add(new Location(i, j));
                }
            }

            return gridLocations;
        }

        private IEnumerable<ILocation> GetNeighboursFor(ILocation location)
        {
            var row = location.RowNumber;
            var column = location.ColumnNumber;
            var leftColumn = column == 1 ? _numberOfColumns : column - 1;
            var rightColumn = column == _numberOfColumns ?  1 : column + 1;
            var aboveRow = row == 1 ? _numberOfRows : row - 1;
            var belowRow = row == _numberOfRows ? 1 : row + 1;
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