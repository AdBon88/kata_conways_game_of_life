using System;
using System.Linq;

namespace kata_conways_game_of_life.InputOutput
{
    public class InputParser
    {
        private readonly IInput _prompt;

        public InputParser(IInput prompt)
        {
            _prompt = prompt;
        }
        public int ParseGridDimension(string dimension)
        {
            var input = _prompt.GetGridDimension(dimension);
            var isInputValid = Validator.IsGridDimensionValid(input);
            if (isInputValid) return int.Parse(input);
            Console.WriteLine("Error: Invalid dimension!");
            return ParseGridDimension(dimension);
        }

        public int[] GetStartingLiveLocation(int maxRow, int maxColumn)
        {
            var input = _prompt.GetStartingLiveLocation();
            var isInputValid = Validator.AreCoordinatesValidNumbers(input);
            if (isInputValid)
            {
                var coordinates = input.Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var isInputWithinGridBoundaries =
                    Validator.AreCoordinatesWithinGridBoundaries(coordinates, maxRow, maxColumn);
                if (isInputWithinGridBoundaries) return coordinates;
                Console.WriteLine("Error! Coordinates are not within grid boundaries");
            }
            else
            {
                Console.WriteLine("Error! Coordinates are not valid numbers");
            }

            return GetStartingLiveLocation(maxRow, maxColumn);
        }


        public bool GetAdditionalLocations()
        {
            var input = _prompt.GetAdditionalStartingLocations().ToLower();
            return input == "y";
        }
    }
}