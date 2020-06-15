using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Xunit;
using Moq;

namespace kata_conways_game_of_life.tests
{
    public class GridShould
    {
        public GridShould()
        {
            _sut = new Grid(5, 5);
            _sut.AddCellsToLocations();
        }

        private readonly Grid _sut;
        
        [Fact]
        public void ContainCorrectNumberOfSquares()
        {
            _sut.AddCellsToLocations();
            
            var expectedDisplay = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expectedDisplay, _sut.Display());
        }

        [Fact]
        public void CalculateCorrectLiveNeighbourCountForNonBoundaryLocation()
        {

            AddLiveCellTo(2, 2);
            AddLiveCellTo(5, 5);

            var targetLocation = _sut.GetLocationAt(3, 3);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);
            
            Assert.Equal(1, actual);
        }

        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryLeftColumnLocation()
        {
            AddLiveCellTo(2, 5);
            AddLiveCellTo(4, 1);
            AddLiveCellTo(3, 5);
            AddLiveCellTo(1, 1);
            
            var targetLocation = _sut.GetLocationAt(3, 1);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);
            
            Assert.Equal(3, actual);
        }
        
        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryRightColumnLocation()
        {
            AddLiveCellTo(2, 4);
            AddLiveCellTo(2, 5);
            AddLiveCellTo(2, 1);
            AddLiveCellTo(3, 4);
            AddLiveCellTo(3, 1);
            AddLiveCellTo(4, 4);
            AddLiveCellTo(4, 5);
            AddLiveCellTo(4, 1);
            AddLiveCellTo(1, 1);
            
            var targetLocation = _sut.GetLocationAt(3, 5);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);
            
            Assert.Equal(8, actual);

        }
        
        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryTopRowLocation()
        {
            AddLiveCellTo(5, 2);
            AddLiveCellTo(5, 3);
            AddLiveCellTo(5, 4);
            AddLiveCellTo(1, 2);
            AddLiveCellTo(1, 4);
            AddLiveCellTo(2, 2);
            AddLiveCellTo(2, 3);

            var targetLocation = _sut.GetLocationAt(1, 3);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);
            
            Assert.Equal(7, actual);

        }
        
        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryBottomRowLocation()
        {
            AddLiveCellTo(4, 1);
            AddLiveCellTo(4, 2);
            AddLiveCellTo(4, 3);
            AddLiveCellTo(5, 1);
            AddLiveCellTo(5, 3);
            AddLiveCellTo(1, 1);
            AddLiveCellTo(1, 2);
            AddLiveCellTo(1, 3);
            
            var targetLocation = _sut.GetLocationAt(5, 2);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);
            
            Assert.Equal(8, actual);
        }
        
        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryTopLeftCornerLocation()
        {
            AddLiveCellTo(5, 5);
            AddLiveCellTo(5, 1);
            AddLiveCellTo(5, 2);
            AddLiveCellTo(1, 5);
            AddLiveCellTo(1, 2);
            AddLiveCellTo(2, 5);
            AddLiveCellTo(2, 1);
            AddLiveCellTo(2, 2);
            
            var targetLocation = _sut.GetLocationAt(1, 1);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);
            
            Assert.Equal(8, actual);
        }

        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryTopRightCornerLocation()
        {
            AddLiveCellTo(5, 4);
            AddLiveCellTo(5, 5);
            AddLiveCellTo(5, 1);
            AddLiveCellTo(1, 4);
            AddLiveCellTo(1, 1);
            AddLiveCellTo(2, 4);
            AddLiveCellTo(2, 5);
            AddLiveCellTo(2, 1);

            var targetLocation = _sut.GetLocationAt(1, 5);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);

            Assert.Equal(8, actual);
        }

        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryBottomLeftCornerLocation()
        {
            AddLiveCellTo(4, 5);
            AddLiveCellTo(4, 1);
            AddLiveCellTo(4, 2);
            AddLiveCellTo(5, 5);
            AddLiveCellTo(5, 2);
            AddLiveCellTo(1, 5);
            AddLiveCellTo(1, 1);
            AddLiveCellTo(1, 2);

            var targetLocation = _sut.GetLocationAt(5, 1);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);
            
            Assert.Equal(8, actual);

        }
        
        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryBottomRightCornerLocation()
        {
            AddLiveCellTo(4, 4);
            AddLiveCellTo(4, 5);
            AddLiveCellTo(4, 1);
            AddLiveCellTo(5, 4);
            AddLiveCellTo(5, 1);
            AddLiveCellTo(1, 4);
            AddLiveCellTo(1, 5);
            AddLiveCellTo(1, 1);

            var targetLocation = _sut.GetLocationAt(5, 5);
            var actual = _sut.GetLiveNeighboursCountFor(targetLocation);
            
            Assert.Equal(8, actual);

        }

        [Fact]
        public void GetAListOfLocationsWhereCellsGoFromAliveToDead()
        {
            var targetLocation = _sut.GetLocationAt(3, 3);
            AddLiveCellTo(targetLocation.RowNumber, targetLocation.ColumnNumber);
            
            AddLiveCellTo(2, 2);
            AddLiveCellTo(2, 3);
            AddLiveCellTo(3, 4);
            AddLiveCellTo(3, 5);
            
            Assert.Equal(State.Dead, targetLocation.GetNextCellState(4));
            
        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromAliveToDead()
        {
            var targetLocation1 = _sut.GetLocationAt(3, 3);
            targetLocation1 = Mock.Of<ILocation>(l
                => l.GetCellState() == State.Alive
                   && l.GetNextCellState(It.IsAny<int>()) == State.Dead);
            
            var targetLocation2 = _sut.GetLocationAt(4, 1);
            targetLocation2 = Mock.Of<ILocation>(l 
            => l.GetCellState() == State.Alive &&
               l.GetNextCellState(It.IsAny<int>()) == State.Dead);
            
            
            Assert.Contains(targetLocation1, _sut.GetCellsToDieNext());
            Assert.Contains(targetLocation2, _sut.GetCellsToDieNext());
        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromDeadToAlive()
        {
            var targetLocation1 = _sut.GetLocationAt(1, 1);
            targetLocation1 = Mock.Of<ILocation>(l
                => l.GetCellState() == State.Dead
                   && l.GetNextCellState(It.IsAny<int>()) == State.Alive);
            
            var targetLocation2 = _sut.GetLocationAt(2,5);
            targetLocation2 = Mock.Of<ILocation>(l 
                => l.GetCellState() == State.Dead &&
                   l.GetNextCellState(It.IsAny<int>()) == State.Alive);
            
            Assert.Contains(targetLocation1, _sut.GetCellsToReviveNext());
            Assert.Contains(targetLocation2, _sut.GetCellsToReviveNext());
            
        }

        
        private void AddLiveCellTo(int row, int column)
        {
            var liveLocation = _sut.GetLocationAt(row, column);
            liveLocation.AddCell(Mock.Of<ICell>(c => c.State == State.Alive));
        }

    }
}