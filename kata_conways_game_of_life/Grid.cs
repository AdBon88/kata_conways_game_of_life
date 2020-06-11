using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_conways_game_of_life
{
    public class Grid
    {
        public Grid(int numberOfRows, int numberOfColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            _contents = GenerateGrid();
        }
        
        public int NumberOfRows { get; }
        public int NumberOfColumns { get; }
        private readonly IEnumerable<Location> _contents;
        
        private IEnumerable<Location> GenerateGrid()
        {
            var gridLocations = new List<Location>();
            for (int i = 1; i <= NumberOfRows; i++)
            {
                for (int j = 1; j <= NumberOfColumns; j++)
                {
                    gridLocations.Add(new Location(i, j, new Cell()));
                }
            }

            return gridLocations;
        }

        public string Display()
        {
            var rows = _contents.GroupBy(location => location.RowNumber);
            var gridDisplay = "";
            
        }
    }
}