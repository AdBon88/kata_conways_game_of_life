using System;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;

namespace kata_conways_game_of_life.Actions
{
    public class GridSetUp
    {
        public IGrid CreateGridWithCells(int numberOfRows, int numberOfColumns)
        {
            IGrid grid = new Grid(numberOfRows, numberOfColumns);
            grid.AddCellsToLocations();
            return grid;
        }
        

    }
}