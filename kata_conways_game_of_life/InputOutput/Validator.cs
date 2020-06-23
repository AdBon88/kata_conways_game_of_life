using System;
using System.Linq;

namespace kata_conways_game_of_life.InputOutput
{
    public static class Validator
    {
        public static bool AreCoordinatesValidNumbers(string coordinates)
        {
            var splitCoordinates = coordinates.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var isEachCoordinateValid = splitCoordinates.Select(coordinate => 
                int.TryParse(coordinate, out var number));
            return isEachCoordinateValid.All(isValid => isValid);
            
        }

        public static bool AreCoordinatesWithinGridBoundaries(int[] coordinates, int maxGridRow, int maxGridColumn)
        {
            var isXCoordinateValid = (coordinates[0] > 0) && (coordinates[0] <= maxGridRow);
            var isYCoordinateValid = (coordinates[1] > 0) && (coordinates[1] <= maxGridColumn);
            return isXCoordinateValid && isYCoordinateValid;
        }

        public static bool IsGridDimensionValid(string dimension)
        {
            var isDimensionValid = int.TryParse(dimension, out var intDimension);
            return isDimensionValid && intDimension >= 5;
        }
    }
}