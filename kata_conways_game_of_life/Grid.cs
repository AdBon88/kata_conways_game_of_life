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
            _numberOfRows = numberOfRows;
            _numberOfColumns = numberOfColumns;
            _locations = GenerateGrid();
        }
        
        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;
        private readonly IEnumerable<Location> _locations;


        private IEnumerable<Location> GenerateGrid()
        {
            var gridLocations = new List<Location>();
            for (var i = 1; i <= _numberOfRows; i++)
            {
                for (var j = 1; j <= _numberOfColumns; j++)
                {
                    gridLocations.Add(new Location(i, j, new Cell()));
                }
            }

            return gridLocations;
        }

        public string Display()
        {
            var gridDisplay = new StringBuilder();
            for (var rowNumber = 1; rowNumber <= _numberOfRows; rowNumber++)
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
            var leftColumn = column == 1 ? _numberOfColumns : column - 1;
            var rightColumn = column == _numberOfColumns ?  1 : column + 1;
            var aboveRow = row == 1 ? _numberOfRows : row - 1;
            var belowRow = row == _numberOfRows ? 1 : row + 1;
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