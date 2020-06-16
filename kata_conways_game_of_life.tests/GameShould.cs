using System.Collections.Generic;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class GameShould
    {
        [Fact]
        public void GetNextCellStateAtEachGameLoop()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(g => g.AreAllCellsDead())
                .Returns(true);
            
            var sut = new Game(mockGrid.Object);
            sut.Run();
            
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
            
            var sut = new Game(mockGrid.Object);
            sut.Run();
            
            testLocation1.Verify(l => l.ChangeCellStateTo(State.Dead), Times.Once);
            testLocation2.Verify(l => l.ChangeCellStateTo(State.Dead), Times.Once);

        }
        
        

    }
}