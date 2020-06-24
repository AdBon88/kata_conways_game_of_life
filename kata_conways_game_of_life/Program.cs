using System;
using kata_conways_game_of_life.Actions;
using kata_conways_game_of_life.InputOutput;
using kata_conways_game_of_life.Models;
using Figgle;

namespace kata_conways_game_of_life
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Bubble.Render("Conway's Game of Life"));
            var prompt = new Input();
            var userInputParser = new InputParser(prompt);
            var numberOfRows = userInputParser.ParseGridDimension("rows");
            var numberOfColumns = userInputParser.ParseGridDimension("columns");
            var grid = new Grid(numberOfRows, numberOfColumns);
            grid.SetNeighboursForAllLocations();
            grid.AddDeadCellsToAllLocations();
            Console.Clear();
            Console.WriteLine(grid.GetFormattedGrid());
            var game = new Game(grid, userInputParser);
            game.SetUpStartingGrid();
            game.UpdateGridAtEachTick();
        }

    }
}