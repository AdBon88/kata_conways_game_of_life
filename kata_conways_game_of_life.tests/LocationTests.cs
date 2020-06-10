using System.Collections.Generic;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class LocationTests
    {
        [Fact]
        public void HaveALiveCellNextIfHaveTwoToThreeLiveNeighboursAndCurrentLiveCell()
        {
            var sut = new Location(2, 2, new Cell() {State = State.Alive});
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()
            };

            sut.Neighbours = neighbours;
            
            Assert.Equal(State.Alive, sut.GetNextCellState());
        }

        [Fact]
        public void HaveALiveCellNextIfCurrentlyHasDeadCellAndExactly3LiveNeighbours()
        {
            var sut = new Location(2, 2, new Cell());
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell(), new Cell(), new Cell()
            };

            sut.Neighbours = neighbours;
            
            Assert.Equal(State.Alive, sut.GetNextCellState());
        }
        
        public void HaveADeadCellNextIfCurrentlyHasDeadCellAndNot3LiveNeighbours()
        {
            var sut = new Location(2, 2, new Cell());
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell(), new Cell(), new Cell()
            };

            sut.Neighbours = neighbours;
            
            Assert.Equal(State.Dead, sut.GetNextCellState());
        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndLessThan2LiveNeighbours()
        {
            var sut = new Location(2, 2, new Cell() {State = State.Alive});
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()
            };

            sut.Neighbours = neighbours;
            
            Assert.Equal(State.Dead, sut.GetNextCellState());

        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndMoreThan3LiveNeighbours()
        {
            var sut = new Location(2, 2, new Cell() {State = State.Alive});
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell()
            };

            sut.Neighbours = neighbours;
            
            Assert.Equal(State.Dead, sut.GetNextCellState());

            
        }
        
        
    }
}