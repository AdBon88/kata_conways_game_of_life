using System;
using System.Linq;

namespace kata_conways_game_of_life.InputOutput
{
    public static class Validator
    {
        
        public static bool IsLocationInGrid(int[] coordinates, int maxGridRow, int maxGridColumn)
        {
            var isXCoordinateValid = (coordinates[0] > 0) && (coordinates[0] <= maxGridRow);
            var isYCoordinateValid = (coordinates[1] > 0) && (coordinates[1] <= maxGridColumn);
            return isXCoordinateValid && isYCoordinateValid;
        }

        public static bool IsDimensionValid(int dimension)
        {
            return dimension >= 5;
        }
    }
}