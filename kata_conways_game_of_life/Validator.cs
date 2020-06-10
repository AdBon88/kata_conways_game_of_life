using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_conways_game_of_life
{
    public static class Validator
    {
        public static bool AreCoordinatesValidNumbers(string coordinates)
        {
            var splitCoordinates = coordinates.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var isEachCoordinateValid = splitCoordinates.Select(coordinate => int.TryParse(coordinate, out var number));
            return isEachCoordinateValid.All(isValid => isValid);
            
        }

        public static bool AreCoordinatesWithinGridBoundaries(IEnumerable<int> coordinates, int maxGridRow, int maxGridColumn)
        {
            var isXCoordinateValid = (coordinates.First() > 0) && (coordinates.First() <= maxGridRow);
            var isYCoordinateValid = (coordinates.Last() > 0) && (coordinates.Last() <= maxGridColumn);
            return isXCoordinateValid && isYCoordinateValid;
        }
    }
}