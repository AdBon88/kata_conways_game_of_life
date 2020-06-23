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
        public void SetsCorrectNeighboursFor_NonBoundaryLocation()
        {
            var targetLocation = _sut.GetLocationAt(3, 3);
            ReviveCellAtLocation(2, 2);
            ReviveCellAtLocation(2,4);
            ReviveCellAtLocation(4, 3);
            ReviveCellAtLocation(5, 5);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void SetsCorrectNeighboursFor_BoundaryLeftColumnLocation()
        {
            var targetLocation = _sut.GetLocationAt(3, 1);
            ReviveCellAtLocation(2, 5);
            ReviveCellAtLocation(4, 1);
            ReviveCellAtLocation(3, 5);
            ReviveCellAtLocation(1, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }
        
        [Fact]
        public void SetsCorrectNeighboursFor_BoundaryRightColumnLocation()
        {
            var targetLocation = _sut.GetLocationAt(3, 5);
            ReviveCellAtLocation(2, 1);
            ReviveCellAtLocation(3, 4);
            ReviveCellAtLocation(4, 1);
            ReviveCellAtLocation(1, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void SetsCorrectNeighboursFor_BoundaryTopRowLocation()
        {
            var targetLocation = _sut.GetLocationAt(1, 3);
            ReviveCellAtLocation(5, 3);
            ReviveCellAtLocation(1, 2);
            ReviveCellAtLocation(2, 2);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void SetsCorrectNeighboursFor_BoundaryBottomRowLocation()
        {
            var targetLocation = _sut.GetLocationAt(5, 2);
            ReviveCellAtLocation(4, 1);
            ReviveCellAtLocation(5, 3);
            ReviveCellAtLocation(1, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }
        
        [Fact]
        public void SetsCorrectNeighboursFor_BoundaryTopLeftCornerLocation()
        {
            var targetLocation = _sut.GetLocationAt(1, 1);
            ReviveCellAtLocation(5, 5);
            ReviveCellAtLocation(1, 2);
            ReviveCellAtLocation(2, 5);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void SetsCorrectNeighboursFor_BoundaryTopRightCornerLocation()
        {
            var targetLocation = _sut.GetLocationAt(1, 5);
            ReviveCellAtLocation(5, 4);
            ReviveCellAtLocation(1, 1);
            ReviveCellAtLocation(2, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);
        }

        [Fact]
        public void SetsCorrectNeighboursFor_BoundaryBottomLeftCornerLocation()
        {
            var targetLocation = _sut.GetLocationAt(5, 1);
            ReviveCellAtLocation(4, 5);
            ReviveCellAtLocation(5, 2);
            ReviveCellAtLocation(1, 5);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void SetsCorrectNeighboursFor_BoundaryBottomRightCornerLocation()
        {
            var targetLocation = _sut.GetLocationAt(5, 5);
            ReviveCellAtLocation(4, 1);
            ReviveCellAtLocation(1, 4);
            ReviveCellAtLocation(1, 1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Equal(State.Alive, targetLocation.NextCellState);

        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromAliveToDead()
        {
            var expectedLocation1 = _sut.GetLocationAt(2, 3);
            var expectedLocation2 = _sut.GetLocationAt(2, 4);
            ReviveCellAtLocation(1,2);
            ReviveCellAtLocation(1,4);
            ReviveCellAtLocation(1,5);
            ReviveCellAtLocation(2,2);
            ReviveCellAtLocation(2,3);
            ReviveCellAtLocation(2,4);
            ReviveCellAtLocation(3,3);
            ReviveCellAtLocation(3,4);

            
            _sut.SetNextCellStateForAllLocations();

            Assert.Contains(expectedLocation1, _sut.GetLocationsToKillCells());
            Assert.Contains(expectedLocation2, _sut.GetLocationsToKillCells());
            
        }
        
        [Fact]
        public void GetAListOfLocationsWhereCellStateChangesFromDeadToAlive()
        {
            var expectedLocation1 = _sut.GetLocationAt(3, 4);
            var expectedLocation2 = _sut.GetLocationAt(5, 1);
            ReviveCellAtLocation(2,3);
            ReviveCellAtLocation(2,4);
            ReviveCellAtLocation(3,3);
            ReviveCellAtLocation(4,1);
            ReviveCellAtLocation(5,2);
            ReviveCellAtLocation(1,1);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.Contains(expectedLocation1, _sut.GetLocationsToReviveCells());
            Assert.Contains(expectedLocation2, _sut.GetLocationsToReviveCells());
        }

        [Fact]
        public void DetectWhenGridConfigurationStopsChanging()
        {
            ReviveCellAtLocation(3, 3);
            ReviveCellAtLocation(3,4);
            ReviveCellAtLocation(4,3);
            ReviveCellAtLocation(4,4);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.False(_sut.ConfigurationIsChanging());
        }
        
        [Fact]
        public void DetectIfGridConfigurationIsChanging()
        {
            ReviveCellAtLocation(1, 3);
            ReviveCellAtLocation(3,5);
            ReviveCellAtLocation(4,3);
            ReviveCellAtLocation(5,5);
            
            _sut.SetNextCellStateForAllLocations();
            
            Assert.True(_sut.ConfigurationIsChanging());
        }
        
        [Fact]
        public void DetectIfAllLocationsContainDeadCells()
        {
            Assert.False(_sut.HasLiveCells());
            
            ReviveCellAtLocation(4, 4);

            Assert.True(_sut.HasLiveCells());
        }

        private void ReviveCellAtLocation(int row, int column)
        {
            var targetLocation = _sut.GetLocationAt(row, column);
            targetLocation.ChangeCellStateTo(State.Alive);
        }

    }
}