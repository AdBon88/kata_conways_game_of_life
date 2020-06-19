using System;
using kata_conways_game_of_life.Models;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class GridShould
    {
        public GridShould()
        {
            _sut = new Grid(5, 5);
            _sut.SetNeighboursForAllLocations();
            _sut.AddDeadCellsToAllLocations();
        }

        private readonly Grid _sut;
        
        [Fact]
        public void ContainCorrectNumberOfSquares()
        {
            var expectedDisplay = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expectedDisplay, _sut.Display());
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateFor_NonBoundaryLocation()
        {
            var targetLocation = _sut.GetLocationAt(3, 3);
            MakeCellLiveAtLocation(2, 2);
            MakeCellLiveAtLocation(2,4);
            MakeCellLiveAtLocation(4, 3);
            MakeCellLiveAtLocation(5, 5);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateFor_BoundaryLeftColumnLocation()
        {
            var targetLocation = _sut.GetLocationAt(3, 1);
            MakeCellLiveAtLocation(2, 5);
            MakeCellLiveAtLocation(4, 1);
            MakeCellLiveAtLocation(3, 5);
            MakeCellLiveAtLocation(1, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateFor_BoundaryRightColumnLocation()
        {
            var targetLocation = _sut.GetLocationAt(3, 5);
            MakeCellLiveAtLocation(2, 1);
            MakeCellLiveAtLocation(3, 4);
            MakeCellLiveAtLocation(4, 1);
            MakeCellLiveAtLocation(1, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateFor_BoundaryTopRowLocation()
        {
            var targetLocation = _sut.GetLocationAt(1, 3);
            MakeCellLiveAtLocation(5, 3);
            MakeCellLiveAtLocation(1, 2);
            MakeCellLiveAtLocation(2, 2);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateFor_BoundaryBottomRowLocation()
        {
            var targetLocation = _sut.GetLocationAt(5, 2);
            MakeCellLiveAtLocation(4, 1);
            MakeCellLiveAtLocation(5, 3);
            MakeCellLiveAtLocation(1, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }
        
        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateFor_BoundaryTopLeftCornerLocation()
        {
            var targetLocation = _sut.GetLocationAt(1, 1);
            MakeCellLiveAtLocation(5, 5);
            MakeCellLiveAtLocation(1, 2);
            MakeCellLiveAtLocation(2, 5);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateFor_BoundaryTopRightCornerLocation()
        {
            var targetLocation = _sut.GetLocationAt(1, 5);
            MakeCellLiveAtLocation(5, 4);
            MakeCellLiveAtLocation(1, 1);
            MakeCellLiveAtLocation(2, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void UseCorrectNeighboursToGetNextCellStateFor_BoundaryBottomLeftCornerLocation()
        {
            var targetLocation = _sut.GetLocationAt(5, 1);
            MakeCellLiveAtLocation(4, 5);
            MakeCellLiveAtLocation(5, 2);
            MakeCellLiveAtLocation(1, 5);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void CalculateCorrectLiveNeighboursForBoundaryBottomRightCornerLocation()
        {
            var targetLocation = _sut.GetLocationAt(5, 5);
            MakeCellLiveAtLocation(4, 1);
            MakeCellLiveAtLocation(1, 4);
            MakeCellLiveAtLocation(1, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromAliveToDead()
        {
            var expectedLocation1 = _sut.GetLocationAt(2, 3);
            var expectedLocation2 = _sut.GetLocationAt(2, 4);
            MakeCellLiveAtLocation(1,2);
            MakeCellLiveAtLocation(1,4);
            MakeCellLiveAtLocation(1,5);
            MakeCellLiveAtLocation(2,2);
            MakeCellLiveAtLocation(2,3);
            MakeCellLiveAtLocation(2,4);
            MakeCellLiveAtLocation(3,3);
            MakeCellLiveAtLocation(3,4);

            
            _sut.SetNextCellStateForAllLocations();

            Assert.Contains(expectedLocation1, _sut.GetLocationsToKillCells());
            Assert.Contains(expectedLocation2, _sut.GetLocationsToKillCells());
            
        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromDeadToAlive()
        {
            var expectedLocation1 = _sut.GetLocationAt(3, 4);
            var expectedLocation2 = _sut.GetLocationAt(5, 1);
            MakeCellLiveAtLocation(2,3);
            MakeCellLiveAtLocation(2,4);
            MakeCellLiveAtLocation(3,3);
            MakeCellLiveAtLocation(4,1);
            MakeCellLiveAtLocation(5,2);
            MakeCellLiveAtLocation(1,1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Contains(expectedLocation1, _sut.GetLocationsToReviveCells());
            Assert.Contains(expectedLocation2, _sut.GetLocationsToReviveCells());
        }

        [Fact]
        public void DetectWhenGridConfigurationStopsChanging()
        {
            MakeCellLiveAtLocation(3, 3);
            MakeCellLiveAtLocation(3,4);
            MakeCellLiveAtLocation(4,3);
            MakeCellLiveAtLocation(4,4);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.False(_sut.ConfigurationIsChanging());
        }
        
        [Fact]
        public void DetectIfGridConfigurationIsChanging()
        {
            MakeCellLiveAtLocation(1, 3);
            MakeCellLiveAtLocation(3,5);
            MakeCellLiveAtLocation(4,3);
            MakeCellLiveAtLocation(5,5);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.True(_sut.ConfigurationIsChanging());
        }
        
        [Fact]
        public void DetectIfAllLocationsContainDeadCells()
        {
            Assert.False(_sut.HasLiveCells());
            
            MakeCellLiveAtLocation(4, 4);

            Assert.True(_sut.HasLiveCells());
        }

        private void MakeCellLiveAtLocation(int row, int column)
        {
            var targetLocation = _sut.GetLocationAt(row, column);
            targetLocation.ChangeCellStateTo(State.Alive);
        }

    }
}