using System;
using kata_conways_game_of_life.InputOutput;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class InputParserShould
    {
        [Theory]
        [InlineData("4, 5")]
        public void ConvertStringLocationToInteger(string input)
        {
            var actual = InputParser.ParseInputCoordinates(input);
            
          Assert.Equal(new int[] {4, 5}, actual);
        }

        [Theory]
        [InlineData("a, 4")]
        public void ThrowErrorIfInputCoordinatesAreInvalid(string input)
        {
            Assert.ThrowsAny<Exception>(() => InputParser.ParseInputCoordinates(input));
        }

    }
}