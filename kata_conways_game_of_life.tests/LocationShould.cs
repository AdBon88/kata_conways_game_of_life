using System.Collections.Generic;
using kata_conways_game_of_life.Models;
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
        public void HaveALiveCellNextIfHaveTwoLiveNeighboursAndCurrentLiveCell()
        {
            var sut = new Location(2, 2);
            var neighbours = CreateNeighboursWithLiveNeighbourCountOf(2);
            sut.SetNeighbours(neighbours);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Alive);
            sut.AddCell(cellStub);

            sut.SetNextCellState();
            
            Assert.Equal(State.Alive, sut.NextCellState );
        }
        
        [Fact]
        public void HaveALiveCellNextIfHaveTThreeLiveNeighboursAndCurrentLiveCell()
        {
            var sut = new Location(2, 2);
            var neighbours = CreateNeighboursWithLiveNeighbourCountOf(3);
            sut.SetNeighbours(neighbours);

            var cellStub = Mock.Of<ICell>(c => c.State == State.Alive);
            sut.AddCell(cellStub);
            
            sut.SetNextCellState();
            
            Assert.Equal(State.Alive, sut.NextCellState );
        }

        [Fact]
        public void HaveALiveCellNextIfCurrentlyHasDeadCellAndExactly3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var neighbours = CreateNeighboursWithLiveNeighbourCountOf(3);
            sut.SetNeighbours(neighbours);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Dead);
            sut.AddCell(cellStub);
            
            sut.SetNextCellState();
            
            Assert.Equal(State.Alive, sut.NextCellState);
        }
        
        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasDeadCellAndNot3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var neighbours = CreateNeighboursWithLiveNeighbourCountOf(2);
            sut.SetNeighbours(neighbours);

            var cellStub = Mock.Of<ICell>(c => c.State == State.Dead);
            sut.AddCell(cellStub);
            
            sut.SetNextCellState();
            
            Assert.Equal(State.Dead, sut.NextCellState );
        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndLessThan2LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var neighbours = CreateNeighboursWithLiveNeighbourCountOf(1);
            sut.SetNeighbours(neighbours);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Alive);
            sut.AddCell(cellStub);
            
            sut.SetNextCellState();

            Assert.Equal(State.Dead, sut.NextCellState);
        }

        [Fact]
        public void HaveADeadCellNextIfCurrentlyHasLiveCellAndMoreThan3LiveNeighbours()
        {
            var sut = new Location(2, 2);
            var neighbours = CreateNeighboursWithLiveNeighbourCountOf(4);
            sut.SetNeighbours(neighbours);
            var cellStub = Mock.Of<ICell>(c => c.State == State.Alive);
            sut.AddCell(cellStub);
            
            sut.SetNextCellState();
            
            Assert.Equal(State.Dead, sut.NextCellState);
            
        }

        private static IEnumerable<ILocation> CreateNeighboursWithLiveNeighbourCountOf(int numberOfLiveNeighbours)
        {
            var neighbours = new List<ILocation>();
            for (var i = 0; i < numberOfLiveNeighbours; i++)
            {
                var mockLocation = Mock.Of<ILocation>(l => l.GetCellState() == State.Alive);
                neighbours.Add(mockLocation);
            }

            var numberOfDeadNeighbours = 8 - numberOfLiveNeighbours;

            for (var i = 0; i < numberOfDeadNeighbours; i++)
            {
                var mockLocation = Mock.Of<ILocation>(l => l.GetCellState() == State.Dead);
                neighbours.Add(mockLocation);
            }
            return neighbours;
        }
        
    }
}