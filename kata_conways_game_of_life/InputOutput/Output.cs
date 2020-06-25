using System;

namespace kata_conways_game_of_life.InputOutput
{
    public static class Output
    {
        public static void DisplayString(string contents)
        {
            Console.WriteLine(contents);
        }

        public static void ErrorMessage(string message)
        {
            Console.WriteLine("Error! " + message);
        }
    }
}