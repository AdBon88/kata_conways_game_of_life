using System.Collections.Generic;
using kata_conways_game_of_life.Models;
using Moq;

namespace kata_conways_game_of_life.tests
{
    public static class TestHelper
    {
        public static IEnumerable<ILocation> SetUpNeighbours(int liveNeighbourCount)
        {
            var neighbours = SetUpDeadNeighbours();
            for (var neighbourIndex = 0; neighbourIndex < liveNeighbourCount; neighbourIndex++)
            {
                neighbours[neighbourIndex].ChangeCellStateTo(State.Alive);
            }
            return neighbours;
        }
        
        private static List<ILocation> SetUpDeadNeighbours()
        {
            var neighbour1 = new Location(1, 1);
            neighbour1.AddCell(new Cell());
            var neighbour2 = new Location(1, 2);
            neighbour2.AddCell(new Cell());
            var neighbour3 = new Location(1, 3);
            neighbour3.AddCell(new Cell());
            var neighbour4 = new Location(2, 1);
            neighbour4.AddCell(new Cell());
            var neighbour5 = new Location(2, 3);
            neighbour5.AddCell(new Cell());
            var neighbour6 = new Location(3, 1);
            neighbour6.AddCell(new Cell());
            var neighbour7 = new Location(3, 2);
            neighbour7.AddCell(new Cell());
            var neighbour8 = new Location(3, 3);
            neighbour8.AddCell(new Cell());

            var neighbours = new List<ILocation>
            {
                neighbour1, neighbour2, neighbour3, neighbour4, neighbour5, neighbour6, neighbour7, neighbour8
            };
            
            return neighbours;
        }
    }
}