using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class ValidatorShould
    {
        [Fact]
        public void IndicateIfStringCoordinatesCanBeParsedToIntegers()
        {
            const string coordinates1 = "2, 2";
            const string coordinates2 = "a, 3";
            
            var actual1 = Validator.AreCoordinatesValidNumbers(coordinates1);
            var actual2 = Validator.AreCoordinatesValidNumbers(coordinates2);
            
            Assert.True(actual1);
            Assert.False(actual2);
        }

        [Fact]
        public void IndicateIfCoordinatesAreWithinGridBoundaries()
        {
            var coordinates1 = new int[] {2, 3};
            var coordinates2 = new int[] {1, 4};
            const int maxGridRow = 3;
            const int maxGridColumn = 3;

            var actual1 = Validator.AreCoordinatesWithinGridBoundaries(coordinates1, maxGridRow, maxGridColumn);
            var actual2 = Validator.AreCoordinatesWithinGridBoundaries(coordinates2, maxGridRow, maxGridColumn);

            Assert.True(actual1);
            Assert.False(actual2);
            
        }

        [Fact]
        public void RequireMinimumOf5RowsAndColumnsForGrid()
        {
            const string row = "3";
            const string column = "6";
            
            Assert.False(Validator.IsGridDimensionValid(row));
            Assert.True(Validator.IsGridDimensionValid(column));
        }
        
 
        
    }
}