using System.Collections.Generic;
using kata_conways_game_of_life.Models;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class LocationShould
    {
        public LocationShould()
        {
            _sut = new Location(2, 2);
            _cell = new Cell();
            _sut.AddCell(_cell);
        }

        private readonly Cell _cell;
        private readonly Location _sut;
        
        [Fact]
        public void DisplayAsABlankSquareIfContainsDeadCell()
        {
            Assert.Equal("[ ]", _sut.GetDisplay());
        }

        [Fact]
        public void DisplayAsFilledSquareIfContainsLiveCell()
        {
            _sut.ChangeCellStateTo(State.Alive);

            Assert.Equal("[#]", _sut.GetDisplay());
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void HaveALiveCellNext_IfHasLiveCell_AndTwoOrThreeLiveNeighbours(int numOfLiveNeighbours)
        {
            var neighbours = TestHelper.SetUpNeighbours(numOfLiveNeighbours);
            _sut.SetNeighbours(neighbours);
            _cell.Revive();
            
            _sut.SetNextCellState();
            
            Assert.Equal(State.Alive, _sut.NextCellState );
        }
        
        [Fact]
        public void HaveALiveCellNext_IfHasDeadCell_AndExactly3LiveNeighbours()
        {
            var neighbours = TestHelper.SetUpNeighbours(3);
            _sut.SetNeighbours(neighbours);
            
            _sut.SetNextCellState();
            
            Assert.Equal(State.Alive, _sut.NextCellState);
        }
        
        [Fact]
        public void HaveADeadCellNext_IfHasDeadCell_AndDoesNotHave3LiveNeighbours()
        {
            var neighbours = TestHelper.SetUpNeighbours(2);
            _sut.SetNeighbours(neighbours);
            
            _sut.SetNextCellState();
            
            Assert.Equal(State.Dead, _sut.NextCellState );
        }

        [Fact]
        public void HaveADeadCellNext_IfHasLiveCell_AndLessThan2LiveNeighbours()
        {
            var neighbours = TestHelper.SetUpNeighbours(1);
            _sut.SetNeighbours(neighbours);
            _cell.Revive();

            _sut.SetNextCellState();

            Assert.Equal(State.Dead, _sut.NextCellState);
        }

        [Fact]
        public void HaveADeadCellNext_IfHasLiveCell_AndMoreThan3LiveNeighbours()
        {
            var neighbours = TestHelper.SetUpNeighbours(4);
            _sut.SetNeighbours(neighbours);
            _cell.Revive();

            _sut.SetNextCellState();
            
            Assert.Equal(State.Dead, _sut.NextCellState);
        }

        [Fact]
        public void ReviveCellIfChangeCellStateToAlive()
        {
            _sut.ChangeCellStateTo(State.Alive);
            
            Assert.Equal(State.Alive, _cell.State);
        }
        
        [Fact]
        public void KillCellIfChangeCellStateToDead()
        {
            _sut.ChangeCellStateTo(State.Alive);
            _sut.ChangeCellStateTo(State.Dead);
            
            Assert.Equal(State.Dead, _cell.State);
        }
    }
}