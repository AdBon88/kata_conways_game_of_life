using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kata_conways_game_of_life
{
    public class Grid
    {
        public Grid(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            _locations = GenerateGrid();
        }
        
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        private readonly IEnumerable<Location> _locations;
        
        private IEnumerable<Location> GenerateGrid()
        {
            var gridLocations = new List<Location>();
            for (var i = 1; i <= NumberOfRows; i++)
            {
                for (var j = 1; j <= NumberOfColumns; j++)
                {
                    gridLocations.Add(new Location(i, j, new Cell()));
                }
            }

            return gridLocations;
        }

        public string Display()
        {
            var gridDisplay = new StringBuilder();
            for (var rowNumber = 1; rowNumber <= NumberOfRows; rowNumber++)
            {
                var locationsInRow = _locations.Where(location => location.RowNumber == rowNumber);
                foreach (var location in locationsInRow)
                {
                    gridDisplay.Append(location.Cell.GetDisplay());
                }

                gridDisplay.AppendLine();
            }

            return gridDisplay.ToString();
        }

        public IEnumerable<Location> GetNeighboursFor(int row, int column)
        {
            var leftColumn = column - 1;
            var rightColumn = column + 1;
            var aboveRow = row - 1;
            var belowRow = row + 1;
            return new List<Location>()
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
        
        private Location GetLocationAt(int rowNumber, int columnNumber)
        {
            return _locations.FirstOrDefault(location =>
                location.RowNumber == rowNumber && location.ColumnNumber == columnNumber);
        }
    }
}