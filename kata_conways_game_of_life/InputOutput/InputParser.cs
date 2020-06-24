using System;
using System.Linq;

namespace kata_conways_game_of_life.InputOutput
{
    public class InputParser
    {
        public InputParser(IInput prompt)
        {
            _prompt = prompt;
        }
        
        private readonly IInput _prompt;
        public int ParseGridDimension(string dimensionType)
        {
            var input = _prompt.GetGridDimension(dimensionType);
            var dimension = 0;
            var isDimensionValid = false;
            try
            {
                dimension = int.Parse(input);
                isDimensionValid = Validator.IsDimensionValid(dimension);
                if (!isDimensionValid)
                    throw new ArgumentException("Number of " + dimensionType + " must be at least 5");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return isDimensionValid ? dimension : ParseGridDimension(dimensionType);
        }

        public int[] GetStartingLiveLocation(int maxRow, int maxColumn)
        {
            var input = _prompt.GetStartingLiveLocation();
            var coordinatesString = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var coordinates = new int[2];
            var isLocationInGrid = false;
            try
            {
                coordinates = coordinatesString.Select(int.Parse).ToArray();
                isLocationInGrid  =
                    Validator.IsLocationInGrid(coordinates, maxRow, maxColumn);
                if (!isLocationInGrid) 
                    throw new ArgumentException("Location does not exist!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return isLocationInGrid ? coordinates : GetStartingLiveLocation(maxRow, maxColumn);
        }
        
        public bool IsAddingLocation()
        {
            var input = _prompt.GetAdditionalStartingLocations().ToLower();
            return input == "y";
        }
    }
}