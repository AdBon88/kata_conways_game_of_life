using System;
using System.Text;

namespace kata_conways_game_of_life
{
    public class Prompt : IInput
    {
        public string GetGridDimension(string dimension)
        {
            Console.WriteLine($"Enter the number of {dimension} for the grid (minimum 5): ");
            return Console.ReadLine();
        }

        public string GetStartingLiveLocation()
        {
            Console.WriteLine("Enter a starting location in the form 'row number, column number (both starts at 1)'");
            return Console.ReadLine();
        }

        public string GetAdditionalStartingLocations()
        {
            Console.WriteLine("Would you like to enter more starting locations?"
            + Environment.NewLine
            + "Enter Y to enter another location or any other key to start the game");
            return Console.ReadLine();
        }
    }
}