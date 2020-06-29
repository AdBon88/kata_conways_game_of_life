using System;
using kata_conways_game_of_life.InputOutput;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class ValidatorShould
    {
        [Fact]
        public void CreateInvalidValidationResult_IfCoordinatesExceedBoundary()
        {
            const string coordinates = "1, 4";
            const int maxGridRow = 3;
            const int maxGridColumn = 3;

            var actual = Validator.ValidateCoordinates(coordinates, maxGridRow, maxGridColumn);
            
            Assert.False(actual.IsValid);
            
        }

        [Theory]
        [InlineData("2, 3, 4")]
        [InlineData("2")]
        public void CreatesInvalidValidationResult_IfCoordinatesDoNotHaveTwoIntegers(string coordinates)
        {
            const int maxGridRow = 3;
            const int maxGridColumn = 3;

           var actual= Validator.ValidateCoordinates(coordinates, maxGridRow, maxGridColumn);
           
           Assert.False(actual.IsValid);
           
        }

        [Fact]
        public void CreatesInvalidValidationResult_IfRowsAndColumnsAreNotGreaterThan5()
        {
            const string row = "3";
            const string column = "2";

            var actualRow = Validator.ValidateDimension(row);
            var actualColumn = Validator.ValidateDimension(column);
            
            Assert.False(actualRow.IsValid);
            Assert.False(actualColumn.IsValid);
        }
    }
}