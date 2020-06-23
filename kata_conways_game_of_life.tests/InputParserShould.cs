using System;
using kata_conways_game_of_life.InputOutput;
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
            var sut = new InputParser(mockUserInput.Object);
            mockUserInput.SetupSequence(i => i.GetGridDimension("row"))
                .Returns("a")
                .Returns("2")
                .Returns("5");
            
            Assert.Equal(5, sut.ParseGridDimension("row"));
        }

        [Fact]
        public void ConvertStringLocationToIntegerArrayIfValidNumbersWithinGridBoundaries()
        {
            var mockUserInput = new Mock<IInput>();
            var sut = new InputParser(mockUserInput.Object);
            mockUserInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("a, 4")
                .Returns("7, 3")
                .Returns("4, 5");
            
            Assert.Equal(new int[] {4, 5}, sut.GetStartingLiveLocation(5, 5));
        }

        [Fact]
        public void ReturnABooleanToIndicateIfUserWantsToEnterMoreStartingLocations()
        {
            var mockUserInput = new Mock<IInput>();
            var sut = new InputParser(mockUserInput.Object);
            mockUserInput.Setup(i => i.GetAdditionalStartingLocations())
                         .Returns("n");
            
            Assert.False(sut.IsAddingLocation());
        }
    }
}