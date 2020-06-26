using System;
using System.Linq;

namespace kata_conways_game_of_life.InputOutput
{
    public static class Validator
    {
        public static void ValidateCoordinates(int[] coordinates, int maxGridRow, int maxGridColumn)
        {
            if (coordinates.Length != 2)
                throw new ArgumentException(Messages.CoordinateError);
            var isLocationInGrid  = IsLocationInGrid(coordinates, maxGridRow, maxGridColumn);
            if (!isLocationInGrid) 
                throw new ArgumentException(Messages.LocationError);
        }
        
        public static void ValidateDimension(int dimension)
        {
            if (dimension < 5)
                throw new ArgumentException(Messages.DimensionError);
        }
        
        private static bool IsLocationInGrid(int[] coordinates, int maxGridRow, int maxGridColumn)
        {
            var isXCoordinateValid = (coordinates[0] > 0) && (coordinates[0] <= maxGridRow);
            var isYCoordinateValid = (coordinates[1] > 0) && (coordinates[1] <= maxGridColumn);
            return isXCoordinateValid && isYCoordinateValid;
        }
    }
}