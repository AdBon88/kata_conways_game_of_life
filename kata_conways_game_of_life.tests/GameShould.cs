using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class GameShould
    {
       [Fact]
        public void UpdateInputLocationCellStatesToAlive()
        {
            var mockInput = new Mock<IInput>();
            mockInput.SetupSequence(i => i.GetStartingLiveLocation())
                .Returns("3,3")
                .Returns("2,4")
                .Returns("4,4")
                .Returns("5,5")
                .Returns("1,1");
            
            var inputParser = new InputParser(mockInput.Object);
            IGrid grid = new Grid(5, 5);
            
            var sut = new Game(inputParser, grid);
       
        }

    }
}