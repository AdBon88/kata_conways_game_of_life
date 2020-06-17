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
            _sut.AddDeadCellsToAllLocations();
        }

        private readonly Grid _sut;
        
        [Fact]
        public void ContainCorrectNumberOfSquares()
        {
            _sut.AddDeadCellsToAllLocations();
            
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

            MakeCellLiveAtLocation(2, 2);
            MakeCellLiveAtLocation(2,4);
            MakeCellLiveAtLocation(4, 3);
            MakeCellLiveAtLocation(5, 5);

            var targetLocation = _sut.GetLocationAt(3, 3);
           _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryLeftColumnLocation()
        {
            MakeCellLiveAtLocation(2, 5);
            MakeCellLiveAtLocation(4, 1);
            MakeCellLiveAtLocation(3, 5);
            MakeCellLiveAtLocation(1, 1);
            
            var targetLocation = _sut.GetLocationAt(3, 1);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryRightColumnLocation()
        {
            MakeCellLiveAtLocation(2, 1);
            MakeCellLiveAtLocation(3, 4);
            MakeCellLiveAtLocation(4, 1);
            MakeCellLiveAtLocation(1, 1);
            
            var targetLocation = _sut.GetLocationAt(3, 5);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryTopRowLocation()
        {
            MakeCellLiveAtLocation(5, 3);
            MakeCellLiveAtLocation(1, 2);
            MakeCellLiveAtLocation(2, 2);

            var targetLocation = _sut.GetLocationAt(1, 3);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryBottomRowLocation()
        {
            MakeCellLiveAtLocation(4, 1);
            MakeCellLiveAtLocation(5, 3);
            MakeCellLiveAtLocation(1, 1);
            
            var targetLocation = _sut.GetLocationAt(5, 2);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryTopLeftCornerLocation()
        {
            MakeCellLiveAtLocation(5, 5);
            MakeCellLiveAtLocation(1, 2);
            MakeCellLiveAtLocation(2, 5);
            
            var targetLocation = _sut.GetLocationAt(1, 1);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryTopRightCornerLocation()
        {
            MakeCellLiveAtLocation(5, 4);
            MakeCellLiveAtLocation(1, 1);
            MakeCellLiveAtLocation(2, 1);

            var targetLocation = _sut.GetLocationAt(1, 5);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateForBoundaryBottomLeftCornerLocation()
        {
            MakeCellLiveAtLocation(4, 5);
            MakeCellLiveAtLocation(5, 2);
            MakeCellLiveAtLocation(1, 5);

            var targetLocation = _sut.GetLocationAt(5, 1);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryBottomRightCornerLocation()
        {
            MakeCellLiveAtLocation(4, 1);
            MakeCellLiveAtLocation(1, 4);
            MakeCellLiveAtLocation(1, 1);

            var targetLocation = _sut.GetLocationAt(5, 5);
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromAliveToDead()
        {
            var targetLocation1 = _sut.GetLocationAt(3, 3);
            targetLocation1.ChangeCellStateTo(State.Alive);
            targetLocation1.SetNextCellState(4);
            var targetLocation2 = _sut.GetLocationAt(4, 1);
            targetLocation2.ChangeCellStateTo(State.Alive);
            targetLocation2.SetNextCellState(1);
            
            Assert.Contains(targetLocation1, _sut.GetLocationsToKillCells());
            Assert.Contains(targetLocation2, _sut.GetLocationsToKillCells());
        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromDeadToAlive()
        {
            MakeCellLiveAtLocation(2,3);
            MakeCellLiveAtLocation(2,4);
            MakeCellLiveAtLocation(3,3);
            MakeCellLiveAtLocation(4,1);
            MakeCellLiveAtLocation(5,2);
            MakeCellLiveAtLocation(1,1);

            var expectedLocation1 = _sut.GetLocationAt(3, 4);
            var expectedLocation2 = _sut.GetLocationAt(5, 1);
            

            Assert.Contains(expectedLocation1, _sut.GetLocationsToReviveCells());
            Assert.Contains(expectedLocation2, _sut.GetLocationsToReviveCells());
        }

        [Fact]
        public void DetectIfGridConfigurationIsInfinite()
        {
            MakeCellLiveAtLocation(3, 3);
            MakeCellLiveAtLocation(3,4);
            MakeCellLiveAtLocation(4,3);
            MakeCellLiveAtLocation(4,4);
            
            Assert.True(_sut.IsConfigurationInfinite());
        }
        
        [Fact]
        public void DetectIfGridConfigurationIsNotInfinite()
        {
            MakeCellLiveAtLocation(1, 3);
            MakeCellLiveAtLocation(3,5);
            MakeCellLiveAtLocation(4,3);
            MakeCellLiveAtLocation(5,5);
            
            Assert.False(_sut.IsConfigurationInfinite());
        }
        
        [Fact]
        public void DetectIfAllLocationsContainDeadCellsNext()
        {
            Assert.True(_sut.AreAllCellsDead());
            
            MakeCellLiveAtLocation(4, 4);
            
            Assert.False(_sut.AreAllCellsDead());
        }

        private void MakeCellLiveAtLocation(int row, int column)
        {
            var targetLocation = _sut.GetLocationAt(row, column);
            targetLocation.ChangeCellStateTo(State.Alive);
        }

    }
}