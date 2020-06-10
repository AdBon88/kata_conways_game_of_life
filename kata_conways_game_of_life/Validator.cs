using System;
using System.Linq;

namespace kata_conways_game_of_life
{
    public class Validator
    {
        public static bool AreCoordinatesValidNumbers(string coordinates)
        {
            var splitCoordinates = coordinates.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var isEachCoordinateValid = splitCoordinates.Select(coordinate => int.TryParse(coordinate, out var number));
            return isEachCoordinateValid.All(isValid => isValid == true);
            
        }
    }
}