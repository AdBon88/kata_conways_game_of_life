using System.Collections.Generic;
using System.Linq;
using kata_conways_game_of_life.InputOutput;

namespace kata_conways_game_of_life.tests
{
    public class MockInput : IInput
    {
        private readonly Queue<string> _testInput;

        public MockInput(Queue<string> testInput)
        {
            _testInput = testInput;
        }

        public string ReadInput()
        {
            return _testInput.Dequeue();
        }

    }
}