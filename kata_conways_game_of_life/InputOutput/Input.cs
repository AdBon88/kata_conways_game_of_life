using System;

namespace kata_conways_game_of_life.InputOutput
{
    public class Input : IInput
    {
        public string GetGridDimension(string dimension)
        {
            Console.WriteLine($"Enter the number of {dimension} for the grid (minimum 5): ");
            return Console.ReadLine();
        }

        public string GetStartingLiveLocation()
        {
            Console.WriteLine("Enter a starting location in the form 'row number, column number' or press Enter to start the game");
            return Console.ReadLine();
        }

        public string GetAdditionalStartingLocations()
        {
            Console.WriteLine("Enter Y to add another location or any other key to start the game");
            return Console.ReadLine();
        }
    }
}