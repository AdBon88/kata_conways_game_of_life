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
        public void EndWhenAllCellsAreDead()
        {
            IGrid grid = new Grid(5, 5);
            grid.AddCellsToLocations();
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
        
        //TODO: add test to make sure game ends when expected
        // use concrete classes where possible
        //mention when/why i use mocks for testing

    }
}