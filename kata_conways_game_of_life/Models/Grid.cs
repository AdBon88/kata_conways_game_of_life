using System;
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
        private const int StartingRowNumber = 1;
        private const int StartingColumnNumber = 1;

        public void SetNeighboursForAllLocations()
        {
            foreach (var location in _locations)
            {
                var neighbours = GetNeighboursFor(location);
                location.SetNeighbours(neighbours);
            }
        }

        public void AddDeadCellsToAllLocations()
        {
            foreach (var location in _locations)
            {
                location.AddCell(new Cell());
            }
        }

        public string Display()
        {
            var gridDisplay = "";
            for (var rowNumber = StartingRowNumber; rowNumber <= NumberOfRows; rowNumber++)
            {
                var locationsInRow = _locations.Where(location => location.RowNumber == rowNumber);
                foreach (var location in locationsInRow)
                {
                    gridDisplay += location.GetDisplay();
                }

                gridDisplay += Environment.NewLine;
            }
            return gridDisplay;
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
                location.SetNextCellState();
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
        
        public bool ConfigurationIsChanging()
        {
            return _locations.Any(_location => _location.GetCellState() != _location.NextCellState);
        }
        
        public bool HasLiveCells()
        {
            return _locations.Any(location =>
                location.GetCellState() == State.Alive);
        }
        
        private IEnumerable<ILocation> GenerateGrid()
        {
            var gridLocations = new List<ILocation>();
            for (var i = StartingRowNumber; i <= NumberOfRows; i++)
            {
                for (var j = StartingColumnNumber; j <= NumberOfColumns; j++)
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
            var leftColumn = column == StartingColumnNumber ? NumberOfColumns : column - 1;
            var rightColumn = column == NumberOfColumns ?  StartingColumnNumber : column + 1;
            var aboveRow = row == StartingRowNumber ? NumberOfRows : row - 1;
            var belowRow = row == NumberOfRows ? StartingRowNumber : row + 1;
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