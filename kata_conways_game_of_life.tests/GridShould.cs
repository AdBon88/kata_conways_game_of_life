using System;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class GridShould
    {
        [Fact]
        public void ContainCorrectNumberOfSquares()
        {
            var sut = new Grid(3, 3);

            var expectedDisplay = 
                "[ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expectedDisplay, sut.Display());
        }
        
    }
}