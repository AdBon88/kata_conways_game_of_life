using System;

namespace kata_conways_game_of_life
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

        public int[] GetStartingLiveLocation()
        {
            throw new System.NotImplementedException();
        }
    }
}