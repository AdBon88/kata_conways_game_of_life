using System;
using kata_conways_game_of_life.Actions;
using kata_conways_game_of_life.InputOutput;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class GridSetUpShould
    {
        [Fact]
        public void SetUpGridWithCorrectDimensions()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(i => i.ReadInput())
                .Returns("5")
                .Returns("5");
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;

            var actual = GridSetUp.SetUpGrid(mockInput.Object);
            
            Assert.Equal(expected, actual.GetFormattedString());
        }
        
        [Fact]
        public void ContinueToReceiveDimensionInputsUntilInputIsValid()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(i => i.ReadInput())
                .Returns("a")
                .Returns("5")
                .Returns("b")
                .Returns("5");
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;

            var actual = GridSetUp.SetUpGrid(mockInput.Object);
            
            Assert.Equal(expected, actual.GetFormattedString());
        }
        
    }
}