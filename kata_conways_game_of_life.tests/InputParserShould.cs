using System;
using kata_conways_game_of_life.InputOutput;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class InputParserShould
    {
        public InputParserShould()
        {
            _mockInput = new Mock<IInput>();
            _sut = new InputParser(_mockInput.Object);
        }

        private readonly Mock<IInput> _mockInput;
        private readonly InputParser _sut;
        
        [Fact]
        public void ConvertStringDimensionToIntegerIfValidNumberAbove4()
        {
            _mockInput.SetupSequence(i => i.GetGridDimension("row"))
                .Returns("a")
                .Returns("2")
                .Returns("5");

            var actual = _sut.ParseGridDimension("row");
            
            Assert.Equal(5, actual);
        }

        [Fact(Skip = "need to make into inline data and assert.throws")]
        public void ConvertStringLocationToIntegerArrayIfValidNumbersWithinGridBoundaries()
        {
            _mockInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("a, 4")
                .Returns("7, 3")
                .Returns("4, 5");

          //  var actual = _sut.ParseInputCoordinates(_mockInput, 5, 5);
            
          //  Assert.Equal(new int[] {4, 5}, actual);
        }

    }
}