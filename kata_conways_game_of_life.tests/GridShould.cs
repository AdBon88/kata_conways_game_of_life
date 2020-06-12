using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;

namespace kata_conways_game_of_life.tests
{
    public class GridShould
    {
        //TODO: add location interface and refactor these tests to test live neighbour count method instead
        [Fact]
        public void ContainCorrectNumberOfSquares()
        {
            var sut = new Grid(3, 3);
            sut.AddCellsToLocations();
            
            var expectedDisplay = 
                "[ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expectedDisplay, sut.Display());
        }

        [Fact]
        public void CalculateCorrectLiveNeighbourCountForNonBoundaryLocation() 
    
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(3, 3);
            
            var expectedNeighbours = new List<ILocation>()
            {
                Mock.Of<ILocation>(l => l.GetCellState() == State.Alive 
                                        && l.RowNumber == 2
                                        && l.ColumnNumber == 2),
                new Location(2, 3),
                new Location(2, 4),
                new Location(3, 2),
                new Location(3, 4),
                new Location(4, 2),
                new Location(4, 3),
                new Location(4, 4),
            };
            //
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }
            Assert.Equal(1, actual);
            
        }

        [Fact]
        public void Set8NeighboursToBoundaryLeftColumnLocation()
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(3, 1);

            
            var expectedNeighbours = new List<Location>()
            {
                new Location(2, 5),
                new Location(2, 1),
                new Location(2, 2),
                new Location(3, 5),
                new Location(3, 2),
                new Location(4, 5),
                new Location(4, 1),
                new Location(4, 2)
            };
            
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }

        }
        
        [Fact]
        public void Set8NeighboursToBoundaryRightColumnLocation()
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(3, 5);

            
            var expectedNeighbours = new List<Location>()
            {
                new Location(2, 4),
                new Location(2, 5),
                new Location(2, 1),
                new Location(3, 4),
                new Location(3, 1),
                new Location(4, 4),
                new Location(4, 5),
                new Location(4, 1)
            };
            
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }

        }
        
        [Fact]
        public void Set8NeighboursToBoundaryTopRowLocation()
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(1, 3);

            
            var expectedNeighbours = new List<Location>()
            {
                new Location(5, 2),
                new Location(5, 3),
                new Location(5, 4),
                new Location(1, 2),
                new Location(1, 4),
                new Location(2, 2),
                new Location(2, 3),
                new Location(2, 4)
            };
            
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }

        }
        
        [Fact]
        public void Set8NeighboursToBoundaryBottomRowLocation()
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(5, 2);

            
            var expectedNeighbours = new List<Location>()
            {
                new Location(4, 1),
                new Location(4, 2),
                new Location(4, 3),
                new Location(5, 1),
                new Location(5, 3),
                new Location(1, 1),
                new Location(1, 2),
                new Location(1, 3)
            };
            
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }

        }
        
        [Fact]
        public void Set8NeighboursToBoundaryTopLeftCornerLocation()
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(1, 1);

            
            var expectedNeighbours = new List<Location>()
            {
                new Location(5, 5),
                new Location(5, 1),
                new Location(5, 2),
                new Location(1, 5),
                new Location(1, 2),
                new Location(2, 5),
                new Location(2, 1),
                new Location(2, 2)
            };
            
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }

        }
        
        [Fact]
        public void Set8NeighboursToBoundaryTopRightCornerLocation()
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(1, 5);

            
            var expectedNeighbours = new List<Location>()
            {
                new Location(5, 4),
                new Location(5, 5),
                new Location(5, 1),
                new Location(1, 4),
                new Location(1, 1),
                new Location(2, 4),
                new Location(2, 5),
                new Location(2, 1)
            };
            
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }
        }
        [Fact]
        public void Set8NeighboursToBoundaryBottomLeftCornerLocation()
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(5, 1);

            
            var expectedNeighbours = new List<Location>()
            {
                new Location(4, 5),
                new Location(4, 1),
                new Location(4, 2),
                new Location(5, 5),
                new Location(5, 2),
                new Location(1, 5),
                new Location(1, 1),
                new Location(1, 2)
            };
            
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }
        }
        
        [Fact]
        public void Set8NeighboursToBoundaryBottomRightCornerLocation()
        {
            var sut = new Grid(5, 5);
            var actual = sut.GetLiveNeighboursCountFor(5, 5);

            
            var expectedNeighbours = new List<Location>()
            {
                new Location(4, 4),
                new Location(4, 5),
                new Location(4, 1),
                new Location(5, 4),
                new Location(5, 1),
                new Location(1, 4),
                new Location(1, 5),
                new Location(1, 1)
            };
            
            // for (var i = 0; i < 8; i++)
            // {
            //     Assert.Equal( expectedNeighbours.ElementAt(i).RowNumber,actual.ElementAt(i).RowNumber);
            //     Assert.Equal( expectedNeighbours.ElementAt(i).ColumnNumber,actual.ElementAt(i).ColumnNumber);
            // }
        }
        
        [Fact]
        public void CalculateNumberOfLiveNeighboursForAGivenLocation()
        {
            var sut = new Grid(5, 5);
            sut.AddCellsToLocations();
            AddLiveCellTo(sut, 1, 1);
            AddLiveCellTo(sut, 3, 2);
            AddLiveCellTo(sut, 5, 5);


            Assert.Equal(2, sut.GetLiveNeighboursCountFor(2, 2));

        }

        private static void AddLiveCellTo(Grid grid, int row, int column)
        {
            var liveLocation = grid.GetLocationAt(row, column);
            liveLocation.AddCell(Mock.Of<ICell>(c => c.State == State.Alive));
        }

        

        // [Fact]
        // public void UpdateTheNextCellStateForEachLocation()
        // {
        //     var sut = new Grid(3, 3);
        //     sut.AddCellsToLocations();
        //     sut.ChangeLocationCellState(1, 1, State.Alive);
        //     
        //     Assert.Equal(State.Alive, );
        //     
        // }
        //
        // [Fact]
        // public void UpdateLocationCellStatesWhenGivenStartingLiveCells()
        // {
        //     var sut = new Grid(5, 5);
        //     sut.AddCellsToLocations();
        // }
    }
}