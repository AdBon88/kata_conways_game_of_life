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
        [Fact]
        public void SetCellStateToAliveAtSpecifiedLocationsForGridSetUp()
        {
            var mockInput = new Mock<IInput>();
            var inputParser = new InputParser(mockInput.Object);
            var grid = new Grid(5, 5);
            grid.SetNeighboursForAllLocations();
            grid.AddDeadCellsToAllLocations();
            var sut = new Game(grid, inputParser);
            mockInput.SetupSequence(i => i.GetAdditionalStartingLocations())
                .Returns("y")
                .Returns("y")
                .Returns("n");
            mockInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("2,2")
                .Returns("3,3")
                .Returns("4,4");
            
            sut.SetUpStartingGrid();
            
            var expected =
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][#][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][#][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][#][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, grid.Display());
        }
        
        [Fact]
        public void EndWhenAllCellsAreDead()
        {
            var mockInput = new Mock<IInput>();
            var inputParser = new InputParser(mockInput.Object);
            var grid = new Grid(5, 5);
            grid.SetNeighboursForAllLocations();
            grid.AddDeadCellsToAllLocations();
            var sut = new Game(grid, inputParser);
            mockInput.SetupSequence(i => i.GetAdditionalStartingLocations())
                .Returns("y")
                .Returns("y")
                .Returns("n");
            mockInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("2,2")
                .Returns("1,1")
                .Returns("4,4");
            
            sut.SetUpStartingGrid();
            sut.UpdateGridAtEachTick();
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, grid.Display());
        }

        [Fact]
        public void EndWhenGridConfigurationStopsChanging()
        {
            var mockInput = new Mock<IInput>();
            var inputParser = new InputParser(mockInput.Object);
            var grid = new Grid(5, 5);
            grid.SetNeighboursForAllLocations();
            grid.AddDeadCellsToAllLocations();
            var sut = new Game(grid, inputParser);
            mockInput.SetupSequence(i => i.GetAdditionalStartingLocations())
                .Returns("y")
                .Returns("y")
                .Returns("y")
                .Returns("n");
            mockInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("2,2")
                .Returns("2,3")
                .Returns("3,2")
                .Returns("3,3");
            
            sut.SetUpStartingGrid();
            sut.UpdateGridAtEachTick();
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][#][#][ ][ ]" + Environment.NewLine +
                "[ ][#][#][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, grid.Display());
        }
        
    }
}