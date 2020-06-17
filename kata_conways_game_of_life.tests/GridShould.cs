using System;
using kata_conways_game_of_life.Models;
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
        public void UseCorrectNeighboursToGetNextCellStateForNonBoundaryLocation()
        {

            AddLiveCellTo(2, 2);
            AddLiveCellTo(2,4);
            AddLiveCellTo(4, 3);
            AddLiveCellTo(5, 5);

            var targetLocation = _sut.GetLocationAt(3, 3);
           _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryLeftColumnLocation()
        {
            AddLiveCellTo(2, 5);
            AddLiveCellTo(4, 1);
            AddLiveCellTo(3, 5);
            AddLiveCellTo(1, 1);
            
            var targetLocation = _sut.GetLocationAt(3, 1);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryRightColumnLocation()
        {
            AddLiveCellTo(2, 1);
            AddLiveCellTo(3, 4);
            AddLiveCellTo(4, 1);
            AddLiveCellTo(1, 1);
            
            var targetLocation = _sut.GetLocationAt(3, 5);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryTopRowLocation()
        {
            AddLiveCellTo(5, 3);
            AddLiveCellTo(1, 2);
            AddLiveCellTo(2, 2);

            var targetLocation = _sut.GetLocationAt(1, 3);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryBottomRowLocation()
        {
            AddLiveCellTo(4, 1);
            AddLiveCellTo(5, 3);
            AddLiveCellTo(1, 1);
            
            var targetLocation = _sut.GetLocationAt(5, 2);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryTopLeftCornerLocation()
        {
            AddLiveCellTo(5, 5);
            AddLiveCellTo(1, 2);
            AddLiveCellTo(2, 5);
            
            var targetLocation = _sut.GetLocationAt(1, 1);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryTopRightCornerLocation()
        {
            AddLiveCellTo(5, 4);
            AddLiveCellTo(1, 1);
            AddLiveCellTo(2, 1);

            var targetLocation = _sut.GetLocationAt(1, 5);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryBottomLeftCornerLocation()
        {
            AddLiveCellTo(4, 5);
            AddLiveCellTo(5, 2);
            AddLiveCellTo(1, 5);

            var targetLocation = _sut.GetLocationAt(5, 1);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryBottomRightCornerLocation()
        {
            AddLiveCellTo(4, 1);
            AddLiveCellTo(1, 4);
            AddLiveCellTo(1, 1);

            var targetLocation = _sut.GetLocationAt(5, 5);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }

        [Fact]
        public void CheckIfAllLocationsContainDeadCellsNext()
        {
            Assert.True(_sut.AreAllCellsDead());
        }
        
        private void AddLiveCellTo(int row, int column)
        {
            var liveLocation = _sut.GetLocationAt(row, column);
            liveLocation.AddCell(Mock.Of<ICell>(c => c.State == State.Alive));
        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromAliveToDead()
        {
            var targetLocation1 = _sut.GetLocationAt(3, 3);
            targetLocation1.AddCell(Mock.Of<ICell>(c => c.State == State.Alive));
            targetLocation1.SetNextCellState(4);
            var targetLocation2 = _sut.GetLocationAt(4, 1);
            targetLocation2.AddCell(Mock.Of<ICell>(c => c.State == State.Alive));
            targetLocation2.SetNextCellState(1);
            
            Assert.Contains(targetLocation1, _sut.GetLocationsToKillCells());
            Assert.Contains(targetLocation2, _sut.GetLocationsToKillCells());
        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromDeadToAlive()
        {
            var targetLocation1 = _sut.GetLocationAt(3, 3);
            targetLocation1.AddCell(Mock.Of<ICell>(c => c.State == State.Dead));
            targetLocation1.SetNextCellState(3);
            var targetLocation2 = _sut.GetLocationAt(4, 1);
            targetLocation2.AddCell(Mock.Of<ICell>(c => c.State == State.Dead));
            targetLocation2.SetNextCellState(3);
            
            Assert.Contains(targetLocation1, _sut.GetLocationsToReviveCells());
            Assert.Contains(targetLocation2, _sut.GetLocationsToReviveCells());
        }

    }
}