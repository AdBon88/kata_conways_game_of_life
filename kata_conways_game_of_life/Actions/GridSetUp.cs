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
            var numberOfRows = GetDimension(input, "rows");
            var numberOfColumns = GetDimension(input, "columns");
            var grid = new Grid(numberOfRows, numberOfColumns);
            grid.SetNeighboursForAllLocations();
            grid.AddDeadCellsToAllLocations();
            return grid;
        }

        private static int GetDimension(IInput input, string dimensionType)
        {
            var prompt = dimensionType == "rows" ? Prompts.GridRows : Prompts.GridColumns;
            Output.DisplayString(prompt);
            var inputDimension = input.ReadInput();
            var validationResult = Validator.ValidateDimension(inputDimension);
            if (validationResult.IsValid)
                return validationResult.Dimension;
            Output.ErrorMessage(validationResult.ErrorMessage);
            return GetDimension(input, dimensionType);
        }
    }
}