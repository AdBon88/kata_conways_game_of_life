using System.Collections.Generic;
using kata_conways_game_of_life.Models;
using Moq;

namespace kata_conways_game_of_life.tests
{
    public static class TestHelper
    {
        public static IEnumerable<ILocation> CreateNeighboursWithLiveNeighbourCountOf(int numberOfLiveNeighbours)
        {
            //TODO: use real location and cell objects, rename this method to make it clearer that it's a helper method
            //refactor this to not use for loops
            //TODO: google best practice for helper method
            
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