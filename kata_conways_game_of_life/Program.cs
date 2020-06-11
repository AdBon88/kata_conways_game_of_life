using System;

namespace kata_conways_game_of_life
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Grid(3, 3);
            Console.WriteLine(grid.Display());
        }
    }
}