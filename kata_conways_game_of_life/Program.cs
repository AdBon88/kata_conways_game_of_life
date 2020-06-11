using System;

namespace kata_conways_game_of_life
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows");
            var numOfRows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of columns");
            var numOfColumns = int.Parse(Console.ReadLine());
            var grid = new Grid(numOfRows, numOfColumns);
            Console.WriteLine(grid.Display());
        }
    }
}