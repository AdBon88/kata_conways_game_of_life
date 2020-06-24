using System;

namespace kata_conways_game_of_life.InputOutput
{
    public static class Output
    {
        public static void GridDisplay(string formattedGridString)
        {
            Console.Clear();
            Console.WriteLine(formattedGridString);
            Console.WriteLine(Environment.NewLine);
        }

        public static void ErrorMessage(string message)
        {
            Console.WriteLine("Error! " + message);
        }
    }
}