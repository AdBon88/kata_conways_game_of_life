using System;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class InputParserShould
    {
        [Fact]
        public void ConvertStringDimensionToIntegerIfValidNumberAbove4()
        {
            var mockUserInput = new Mock<IInput>();
            mockUserInput.SetupSequence(i => i.GetGridDimension("row"))
                .Returns("a")
                .Returns("2")
                .Returns("5");
            var sut = new InputParser(mockUserInput.Object);
            
            Assert.Equal(5, sut.ParseGridDimension("row"));
            
        }

        
    }
}