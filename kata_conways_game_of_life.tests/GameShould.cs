using System.Collections.Generic;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class GameShould
    {
       [Fact]
        public void UpdateGridAtEachGameLoop()
        {
             var mockInput = new Mock<IInput>();
            // mockInput.SetupSequence(i => i.GetStartingLiveLocation())
            //     .Returns("3,3")
            //     .Returns("2,4");
            var inputParser = new InputParser(mockInput.Object);
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
            mockGrid.SetupSequence(g => g.WillAllCellsDieNext())
                .Returns(false)
                .Returns(true);


            var sut = new Game(inputParser, mockGrid.Object);
            sut.Run();
            
            mockGrid.Verify(g => g.GetLocationsToKillCells(), Times.Exactly(2));
            mockGrid.Verify(g => g.GetLocationsToReviveCells(), Times.Exactly(2));
            mockGrid.Verify(g => g.WillAllCellsDieNext(), Times.Exactly(2));
            testLocation1.Verify(l => 
                l.GetNextCellState(It.IsAny<int>()), Times.Exactly(2));         
            testLocation2.Verify(l => 
                l.GetNextCellState(It.IsAny<int>()), Times.Exactly(2));
            testLocation1.Verify(l => l.ChangeCellStateTo(State.Dead), Times.Once);
            testLocation2.Verify(l => l.ChangeCellStateTo(State.Dead), Times.Once);

        }

    }
}