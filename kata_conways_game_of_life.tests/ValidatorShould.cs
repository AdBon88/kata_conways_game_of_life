using kata_conways_game_of_life.InputOutput;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class ValidatorShould
    {

        [Fact]
        public void IndicateIfCoordinatesAreWithinGridBoundaries()
        {
            var coordinates1 = new int[] {2, 3};
            var coordinates2 = new int[] {1, 4};
            const int maxGridRow = 3;
            const int maxGridColumn = 3;

            var actual1 = Validator.IsLocationInGrid(coordinates1, maxGridRow, maxGridColumn);
            var actual2 = Validator.IsLocationInGrid(coordinates2, maxGridRow, maxGridColumn);

            Assert.True(actual1);
            Assert.False(actual2);
            
        }

        [Fact]
        public void RequireMinimumOf5RowsAndColumnsForGrid()
        {
            const int row = 3;
            const int column = 6;
            
            Assert.False(Validator.IsDimensionValid(row));
            Assert.True(Validator.IsDimensionValid(column));
        }

    }
}