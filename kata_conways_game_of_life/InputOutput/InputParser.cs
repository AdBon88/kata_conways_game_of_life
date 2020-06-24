using System;
using System.Linq;

namespace kata_conways_game_of_life.InputOutput
{
    public class InputParser
    {
        public InputParser(IInput input)
        {
            _input = input;
        }
        
        private readonly IInput _input;
        public int ParseGridDimension(string dimensionType)
        {
            var input = _input.GetGridDimension(dimensionType);
            var dimension = 0;
            var isDimensionValid = false;
            try
            {
                dimension = int.Parse(input);
                isDimensionValid = Validator.IsDimensionValid(dimension);
                if (!isDimensionValid)
                    throw new ArgumentException(dimensionType + " " + Messages.DimensionError);
            }
            catch (Exception e)
            {
                Output.ErrorMessage(e.Message);
            }

            return isDimensionValid ? dimension : ParseGridDimension(dimensionType);
        }

        public int[] GetStartingLiveLocation(int maxRow, int maxColumn)
        {
            var input = _input.GetStartingLiveLocation();
            var coordinatesString = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var coordinates = new int[2];
            var isLocationInGrid = false;
            try
            {
                coordinates = coordinatesString.Select(int.Parse).ToArray();
                isLocationInGrid  =
                    Validator.IsLocationInGrid(coordinates, maxRow, maxColumn);
                if (!isLocationInGrid) 
                    throw new ArgumentException(Messages.LocationError);
            }
            catch (Exception e)
            {
                Output.ErrorMessage(e.Message);
            }

            return isLocationInGrid ? coordinates : GetStartingLiveLocation(maxRow, maxColumn);
        }
        
        public bool IsAddingLocation()
        {
            var input = _input.GetAdditionalStartingLocations().ToLower();
            return input == "y";
        }
    }
}