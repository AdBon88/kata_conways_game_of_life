using System.Collections.Generic;
using System.Linq;
using kata_conways_game_of_life.InputOutput;

namespace kata_conways_game_of_life.tests
{
    public class MockInput : IInput
    {
        private int _counter;
        private static readonly List<string> TestInput = new List<string>()
        {
            "2,2", "3,3", "4,4", "",
            "2,2", "1,1", "4,4", "",
            "2,2", "2,3", "3,2", "3,3", ""
        };
        public string ReadInput()
        {
            var input = TestInput.First();
            TestInput.RemoveAt(0);
            return input;
        }

    }
}