using System.Collections.Generic;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class LocationShould
    {
        [Fact]
        public void DisplayAsABlankSquareIfContainsDeadCell()
        {
            var sut = new Location(2, 5);
            sut.AddCell(Mock.Of<ICell>(c => c.State == State.Dead));
            
            Assert.Equal("[ ]", sut.GetDisplay());
        }

        [Fact]
        public void DisplayAsFilledSquareIfContainsLiveCell()
        {
            var sut = new Location(2, 5);
            sut.AddCell(Mock.Of<ICell>(c => c.State == State.Alive));

            Assert.Equal("[#]", sut.GetDisplay());
        }
        [Fact]
        public void HaveALiveCellNextIfHaveTwoToThreeLiveNeighboursAndCurrentLiveCell()
        {
            var sut = new Location(2, 2);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Alive);
            sut.AddCell(cellStub);
            
            Assert.Equal(State.Alive, sut.GetNextCellState(2));
            Assert.Equal(State.Alive, sut.GetNextCellState(3));

        }

        [Fact]
        public void HaveALiveCellNextIfCurrentlyHasDeadCellAndExactly3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Dead);
            sut.AddCell(cellStub);
            
            Assert.Equal(State.Alive, sut.GetNextCellState(3));
        }
        
        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasDeadCellAndNot3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Dead);
            sut.AddCell(cellStub);
            Assert.Equal(State.Dead, sut.GetNextCellState(2));
        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndLessThan2LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Alive);
            sut.AddCell(cellStub);

            Assert.Equal(State.Dead, sut.GetNextCellState(1));
        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndMoreThan3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Alive);
            sut.AddCell(cellStub);
            
            Assert.Equal(State.Dead, sut.GetNextCellState(4));
            
        }
        
    }
}