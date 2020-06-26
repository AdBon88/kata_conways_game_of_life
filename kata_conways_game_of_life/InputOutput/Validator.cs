using System;
using System.Linq;

namespace kata_conways_game_of_life.InputOutput
{
    public static class Validator
    {
        private static ValidationResult TryParseCoordinates(string input)
        {
            int[] coordinates;
            try
            {
                coordinates = InputParser.ParseInputCoordinates(input);
            }
            catch (Exception e)
            {
                return ValidationResult.Error(e.Message);
            }
            
            return ValidationResult.Success(coordinates);
        }
        
        public static ValidationResult ValidateCoordinates(string input, int maxGridRow, int maxGridColumn)
        {
            var inputParsedResult = TryParseCoordinates(input);
            if (!inputParsedResult.IsValid) 
                return inputParsedResult;
            var coordinates = inputParsedResult.Coordinates;
            if (!IsFormatValid(coordinates)) 
                return ValidationResult.Error(Messages.CoordinateError);
            var isLocationInGrid  = IsLocationInGrid(coordinates, maxGridRow, maxGridColumn);
            return isLocationInGrid
                ? ValidationResult.Success(coordinates)
                : ValidationResult.Error(Messages.LocationError);
        }
        
        public static ValidationResult ValidateDimension(string input)
        {
            var isInputValid = int.TryParse(input, out var dimension);
            if (!isInputValid) 
                return ValidationResult.Error(Messages.StringToIntError);
            return dimension >= 5
                ? ValidationResult.Success(dimension)
                : ValidationResult.Error(Messages.DimensionError);
        }
        
        private static bool IsFormatValid(int[] coordinates)
        {
            return coordinates.Length == 2;
        }
        
        private static bool IsLocationInGrid(int[] coordinates, int maxGridRow, int maxGridColumn)
        {
            var isXCoordinateValid = (coordinates[0] > 0) && (coordinates[0] <= maxGridRow);
            var isYCoordinateValid = (coordinates[1] > 0) && (coordinates[1] <= maxGridColumn);
            return isXCoordinateValid && isYCoordinateValid;
        }
    }
}