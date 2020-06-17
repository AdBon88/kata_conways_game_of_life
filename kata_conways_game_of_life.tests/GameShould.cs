using System;
using System.Collections.Generic;
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
        public void SetCellStateToAliveAtSpecifiedLocations()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(i => i.GetAdditionalStartingLocations())
                .Returns("y")
                .Returns("y")
                .Returns("n");
            mockInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("2,2")
                .Returns("3,3")
                .Returns("4,4");

            var inputParser = new InputParser(mockInput.Object);
            var grid = new Grid(5, 5);
            grid.AddDeadCellsToAllLocations();
            var sut = new Game(grid, inputParser);

            sut.GetStartingLiveCellLocations();

            var expectedLocation1 = grid.GetLocationAt(2, 2);
            var expectedLocation2 = grid.GetLocationAt(3, 3);
            var expectedLocation3 = grid.GetLocationAt(4, 4);
            
            Assert.Equal(State.Alive, expectedLocation1.GetCellState());
            Assert.Equal(State.Alive, expectedLocation2.GetCellState());
            Assert.Equal(State.Alive, expectedLocation3.GetCellState());
        }
        
        [Fact]
        public void EndWhenAllCellsAreDead()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(i => i.GetAdditionalStartingLocations())
                .Returns("y")
                .Returns("y")
                .Returns("n");
            mockInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("2,2")
                .Returns("1,1")
                .Returns("4,4");

            var inputParser = new InputParser(mockInput.Object);
            var grid = new Grid(5, 5);
            grid.AddDeadCellsToAllLocations();
            var sut = new Game(grid, inputParser);

            sut.GetStartingLiveCellLocations();
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
        public void EndGameWhenGridConfigurationIsInfinite()
        {
            var mockInput = new Mock<IInput>();
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

            var inputParser = new InputParser(mockInput.Object);
            var grid = new Grid(5, 5);
            grid.AddDeadCellsToAllLocations();
            var sut = new Game(grid, inputParser);

            sut.GetStartingLiveCellLocations();
            sut.UpdateGridAtEachTick();
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][#][#][ ][ ]" + Environment.NewLine +
                "[ ][#][#][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, grid.Display());
        }
        
        [Fact]
        public void GetNextCellStateAtEachGameLoop()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(g => g.HasLiveCells())
                .Returns(true);
            
            var sut = new Game(mockGrid.Object, new InputParser(Mock.Of<IInput>()));
            sut.UpdateGridAtEachTick();
            
            mockGrid.Verify(g => g.SetNextCellStateForAllLocations(), Times.Once);
            
        }
        
    }
}