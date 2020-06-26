using System;
using kata_conways_game_of_life.InputOutput;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class ValidatorShould
    {
        [Fact]
        public void ThrowErrorIfCoordinatesExceedBoundary()
        {
            var coordinates = new int[] {1, 4};
            const int maxGridRow = 3;
            const int maxGridColumn = 3;

            Assert.ThrowsAny<Exception>(() => Validator.ValidateCoordinates(coordinates, maxGridRow, maxGridColumn));

        }

        [Theory]
        [InlineData(new int[]{2, 3, 4})]
        [InlineData(new int[] {2})]
        public void ThrowsErrorIfCoordinatesDoNotHaveTwoIntegers(int[] coordinates)
        {
            const int maxGridRow = 3;
            const int maxGridColumn = 3;

            Assert.ThrowsAny<Exception>(() => Validator.ValidateCoordinates(coordinates, maxGridRow, maxGridColumn));
        }

        [Fact]
        public void ThrowErrorIfRowsAndColumnsAreNotGreaterThan5()
        {
            const int row = 3;
            const int column = 2;

            Assert.ThrowsAny<Exception>(() => Validator.ValidateDimension(row));
            Assert.ThrowsAny<Exception>(() => Validator.ValidateDimension(column));
        }
    }
}