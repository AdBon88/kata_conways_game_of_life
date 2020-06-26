using System;
using kata_conways_game_of_life.Actions;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class GameShould
    {
        public GameShould()
        {
            _mockInput = new Mock<IInput>();
            _grid = new Grid(5, 5);
            _grid.SetNeighboursForAllLocations();
            _grid.AddDeadCellsToAllLocations();
            _sut = new Game(_grid, _mockInput.Object);
        }

        private readonly Mock<IInput> _mockInput;
        private readonly Grid _grid;
        private readonly Game _sut;
        
        [Fact]
        public void SetCellStateToAliveAtSpecifiedLocationsForGridSetUp()
        {
            _mockInput.SetupSequence(i => i.ReadInput())
                .Returns("2,2")
                .Returns("3,3")
                .Returns("4,4");
            
            _sut.SetInitialLiveCells();
            
            var expected =
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][#][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][#][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][#][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, _grid.GetFormattedString());
        }
        
        [Fact]
        public void EndWhenAllCellsAreDead()
        {
            _mockInput.SetupSequence(i => i.ReadInput())
                .Returns("2,2")
                .Returns("1,1")
                .Returns("4,4");
            
            _sut.SetInitialLiveCells();
            _sut.UpdateGridAtEachTick();
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, _grid.GetFormattedString());
        }

        [Fact]
        public void EndWhenGridConfigurationStopsChanging()
        {
            _mockInput.SetupSequence(i => i.ReadInput())
                .Returns("2,2")
                .Returns("2,3")
                .Returns("3,2")
                .Returns("3,3");
            
            _sut.SetInitialLiveCells();
            _sut.UpdateGridAtEachTick();
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][#][#][ ][ ]" + Environment.NewLine +
                "[ ][#][#][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, _grid.GetFormattedString());
        }

        
    }
}