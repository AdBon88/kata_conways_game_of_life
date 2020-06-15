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

        [Fact]
        public void ConvertStringLocationToIntegerArrayIfValidNumbersWithinGridBoundaries()
        {
            var mockUserInput = new Mock<IInput>();
            mockUserInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("a, 4")
                .Returns("7, 3")
                .Returns("4, 5");
            var sut = new InputParser(mockUserInput.Object);
            
            Assert.Equal(new int[] {4, 5}, sut.GetStartingLiveLocation(5, 5));
        }

        [Fact]
        public void ReturnABooleanToIndicateIfUserWantsToEnterMoreStartingLocations()
        {
            var mockUserInput = new Mock<IInput>();
            mockUserInput.Setup(i => i.GetAdditionalStartingLocations()).Returns("n");
            var sut = new InputParser(mockUserInput.Object);
            
            Assert.False(sut.GetAdditionalLocations());
            
        }

        
    }
}