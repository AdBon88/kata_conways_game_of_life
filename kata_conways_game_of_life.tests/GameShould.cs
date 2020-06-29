using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using kata_conways_game_of_life.Actions;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;
using Moq;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class GameShould
    {
        public GameShould()
        {
            _grid = new Grid(5, 5);
            _grid.SetNeighboursForAllLocations();
            _grid.AddDeadCellsToAllLocations();
        }
        
        private readonly Grid _grid;
        
        [Fact]
        public void SetCellStateToAliveAtSpecifiedLocationsForGridSetUp()
        {
            // _mockInput.ReadInput()
            //     .Returns("2,2")
            //     .Returns("3,3")
            //     .Returns("4,4");
            var testInput = new Queue<string>();
            testInput.Enqueue("2,2");
            testInput.Enqueue("3,3");
            testInput.Enqueue("4,4");
            testInput.Enqueue("");
            
            var mockInput = new MockInput(testInput);
            var sut = new Game(_grid, mockInput);
            
            sut.SetInitialLiveCells();
            
            var expected =
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][#][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][#][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][#][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, _grid.GetFormattedString());
        }
        
        [Fact]
        public void EndWhenAllCellsAreDead()
        {
            // _mockInput.SetupSequence(i => i.ReadInput())
            //     .Returns("2,2")
            //     .Returns("1,1")
            //     .Returns("4,4");
            
            var testInput = new Queue<string>();
            testInput.Enqueue("2,2");
            testInput.Enqueue("1,1");
            testInput.Enqueue("4,4");
            testInput.Enqueue("");
            
            var mockInput = new MockInput(testInput);
            var sut = new Game(_grid, mockInput);

            sut.SetInitialLiveCells();
            sut.UpdateGridAtEachTick();
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, _grid.GetFormattedString());
        }

        [Fact]
        public void EndWhenGridConfigurationStopsChanging()
        {
            // _mockInput.SetupSequence(i => i.ReadInput())
            //     .Returns("2,2")
            //     .Returns("2,3")
            //     .Returns("3,2")
            //     .Returns("3,3");
            
            var testInput = new Queue<string>();
            testInput.Enqueue("2,2");
            testInput.Enqueue("2,3");
            testInput.Enqueue("3,2");
            testInput.Enqueue("3,3");
            testInput.Enqueue("");
            
            var mockInput = new MockInput(testInput);
            var sut = new Game(_grid, mockInput);
            
            sut.SetInitialLiveCells();
            sut.UpdateGridAtEachTick();
            
            var expected = 
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][#][#][ ][ ]" + Environment.NewLine +
                "[ ][#][#][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine +
                "[ ][ ][ ][ ][ ]" + Environment.NewLine;
            
            Assert.Equal(expected, _grid.GetFormattedString());
        }

        
    }
}