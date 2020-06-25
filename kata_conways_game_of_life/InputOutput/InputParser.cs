using System;
using System.Linq;

namespace kata_conways_game_of_life.InputOutput
{
    public static class InputParser
    {
        public static int[] ParseInputCoordinates(string input)
        {
            var coordinatesString = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var coordinates = coordinatesString.Select(int.Parse).ToArray();
            return coordinates;
        }
        
    }
}