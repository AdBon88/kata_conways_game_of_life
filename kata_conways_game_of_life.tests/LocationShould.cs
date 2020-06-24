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
            _cell = new Cell();
        }

        private readonly ICell _cell;
        
        [Fact]
        public void DisplayAsABlankSquareIfContainsDeadCell()
        {
            var sut = new Location(2, 5);
            sut.AddCell(_cell);
            
            Assert.Equal("[ ]", sut.GetDisplay());
        }

        [Fact]
        public void DisplayAsFilledSquareIfContainsLiveCell()
        {
            var sut = new Location(2, 5);
            _cell.Revive();
            sut.AddCell(_cell);

            Assert.Equal("[#]", sut.GetDisplay());
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void HaveALiveCellNextIfHaveTwoOrThreeLiveNeighboursAndCurrentLiveCell(int numOfLiveNeighbours)
        {
            var sut = new Location(2, 2);
            var neighbours = TestHelper.SetUpNeighbours(numOfLiveNeighbours);
            sut.SetNeighbours(neighbours);
            _cell.Revive();
            sut.AddCell(_cell);

            sut.SetNextCellState();
            
            Assert.Equal(State.Alive, sut.NextCellState );
        }
        
        [Fact]
        public void HaveALiveCellNextIfCurrentlyHasDeadCellAndExactly3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var neighbours = TestHelper.SetUpNeighbours(3);
            sut.SetNeighbours(neighbours);
            sut.AddCell(_cell);
            
            sut.SetNextCellState();
            
            Assert.Equal(State.Alive, sut.NextCellState);
        }
        
        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasDeadCellAndNot3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var neighbours = TestHelper.SetUpNeighbours(2);
            sut.SetNeighbours(neighbours);
            sut.AddCell(_cell);
            
            sut.SetNextCellState();
            
            Assert.Equal(State.Dead, sut.NextCellState );
        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndLessThan2LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var neighbours = TestHelper.SetUpNeighbours(1);
            sut.SetNeighbours(neighbours);
            _cell.Revive();
            sut.AddCell(_cell);
            
            sut.SetNextCellState();

            Assert.Equal(State.Dead, sut.NextCellState);
        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndMoreThan3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var neighbours = TestHelper.SetUpNeighbours(4);
            sut.SetNeighbours(neighbours);
            _cell.Revive();
            sut.AddCell(_cell);
            
            sut.SetNextCellState();
            
            Assert.Equal(State.Dead, sut.NextCellState);
        }

        [Fact]
        public void ReviveCellIfChangeCellStateToAlive()
        {
            var sut = new Location(2, 3);
            sut.AddCell(_cell);
            
            sut.ChangeCellStateTo(State.Alive);
            
            Assert.Equal(State.Alive, _cell.State);
        }
        
        [Fact]
        public void KillCellIfChangeCellStateToDead()
        {

            var sut = new Location(2, 3);
            _cell.Revive();
            sut.AddCell(_cell);
            
            sut.ChangeCellStateTo(State.Dead);
            
            Assert.Equal(State.Dead, _cell.State);
        }
    }
}