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
        //TODO: move try-catch block out into main program
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

        public int[] ParseInputCoordinates(string input)
        {
            var coordinatesString = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var coordinates = coordinatesString.Select(int.Parse).ToArray();
            return coordinates;
        }
        
    }
}