using System.Collections.Generic;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class LocationShould
    {
        [Fact]
        public void HaveALiveCellNextIfHaveTwoToThreeLiveNeighboursAndCurrentLiveCell()
        {
            var sut = new Location(2, 2) {Cell = new Cell() {State = State.Alive}};
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()
            };
            
            Assert.Equal(State.Alive, sut.GetNextCellState(neighbours));
        }

        [Fact]
        public void HaveALiveCellNextIfCurrentlyHasDeadCellAndExactly3LiveNeighbours()
        {
            var sut = new Location(2, 2) {Cell = new Cell()};
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell(), new Cell(), new Cell()
            };
            
            Assert.Equal(State.Alive, sut.GetNextCellState(neighbours));
        }
        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasDeadCellAndNot3LiveNeighbours()
        {
            var sut = new Location(2, 2){Cell = new Cell()};
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell(), new Cell(), new Cell()
            };
            
            Assert.Equal(State.Dead, sut.GetNextCellState(neighbours));
        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndLessThan2LiveNeighbours()
        {
            var sut = new Location(2, 2) {Cell =  new Cell() {State = State.Alive}};
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()
            };
            
            Assert.Equal(State.Dead, sut.GetNextCellState(neighbours));

        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndMoreThan3LiveNeighbours()
        {
            var sut = new Location(2, 2){Cell = new Cell() {State = State.Alive}};
            var neighbours = new List<Cell>()
            {
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell() {State = State.Alive},
                new Cell(), new Cell(), new Cell()
            };
            
            Assert.Equal(State.Dead, sut.GetNextCellState(neighbours));

            
        }
        
        
    }
}