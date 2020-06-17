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
            var mockGrid = new Mock<IGrid>();
            mockGrid.SetupSequence(g => g.IsConfigurationInfinite())
                .Returns(false)
                .Returns(false)
                .Returns(false);
            
            mockGrid.SetupSequence(g => g.AreAllCellsDead())
                .Returns(false)
                .Returns(false)
                .Returns(true);
            
            var sut = new Game(mockGrid.Object, new InputParser(Mock.Of<IInput>()));
            sut.UpdateGridAtEachTick();
            
            mockGrid.Verify(g => g.SetNextCellStateForAllLocations(), Times.Exactly(3));
        }

        [Fact]
        public void EndGameWhenGridConfigurationIsInfinite()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.SetupSequence(g => g.IsConfigurationInfinite())
                .Returns(false)
                .Returns(false)
                .Returns(true);
            
            mockGrid.SetupSequence(g => g.AreAllCellsDead())
                .Returns(false)
                .Returns(false)
                .Returns(false);
            
            var sut = new Game(mockGrid.Object, new InputParser(Mock.Of<IInput>()));
            sut.UpdateGridAtEachTick();
            
            mockGrid.Verify(g => g.SetNextCellStateForAllLocations(), Times.Exactly(3));
            
        }
        
        [Fact]
        public void GetNextCellStateAtEachGameLoop()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(g => g.AreAllCellsDead())
                .Returns(true);
            
            var sut = new Game(mockGrid.Object, new InputParser(Mock.Of<IInput>()));
            sut.UpdateGridAtEachTick();
            
            mockGrid.Verify(g => g.SetNextCellStateForAllLocations(), Times.Once);
            
        }
        
       [Fact]
        public void UpdateGridAtEachGameLoop()
        {
            var testLocation1 = new Mock<ILocation>();
            var testCell1 = Mock.Of<ICell>(c => c.State == State.Alive);
            testLocation1.Setup(l => l.AddCell(testCell1));
            
            var testLocation2 = new Mock<ILocation>();
            var testCell2 = Mock.Of<ICell>(c => c.State == State.Alive);
            testLocation2.Setup(l => l.AddCell(testCell2));
            
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(g => g.GetLocationAt(3, 3))
                .Returns(testLocation1.Object);
            mockGrid.Setup(g => g.GetLocationAt(4, 5))
                .Returns(testLocation2.Object);
            mockGrid.Setup(g => g.GetLocationsToKillCells())
                .Returns(new List<ILocation>() {testLocation1.Object, testLocation2.Object});
            
            mockGrid.Setup(g => g.AreAllCellsDead())
                .Returns(true);
            
            var sut = new Game(mockGrid.Object, new InputParser(Mock.Of<IInput>()));
            sut.UpdateGridAtEachTick();
            
            testLocation1.Verify(l => l.ChangeCellStateTo(State.Dead), Times.Once);
            testLocation2.Verify(l => l.ChangeCellStateTo(State.Dead), Times.Once);

        }


    }
}