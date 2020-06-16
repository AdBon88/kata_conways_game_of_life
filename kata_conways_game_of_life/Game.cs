namespace kata_conways_game_of_life
{
    public class Game
    {
        private readonly InputParser _inputParser;
        private readonly IGrid _grid;

        public Game(InputParser inputParser, IGrid grid)
        {
            _inputParser = inputParser;
            _grid = grid;
        }


    }
}