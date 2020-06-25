using System;

namespace kata_conways_game_of_life.InputOutput
{
    public class Input : IInput
    {
        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}