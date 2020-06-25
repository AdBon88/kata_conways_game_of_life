using System;
using System.Xml;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;

namespace kata_conways_game_of_life.Actions
{
    public static class GridSetUp
    {
        public static Grid SetUpGrid(IInput input)
        {
            var numberOfRows = GetGridDimension(input, "rows");
            var numberOfColumns = GetGridDimension(input, "columns");
            var grid = new Grid(numberOfRows, numberOfColumns);
            grid.SetNeighboursForAllLocations();
            grid.AddDeadCellsToAllLocations();
            return grid;
        }

        private static int GetGridDimension(IInput input, string dimensionType)
        {
            var prompt = dimensionType == "rows" ? Prompts.GridRows : Prompts.GridColumns;
            Output.DisplayString(prompt);
            var inputRows = input.ReadInput();
            var dimension = 0;
            try
            {
                dimension = int.Parse(inputRows);
                Validator.ValidateDimension(dimension);
            }
            catch (Exception e)
            {
                Output.ErrorMessage(e.Message);
                return dimension;
            }

            return dimension > 5 ? dimension : GetGridDimension(input, dimensionType);
        }
    }
}