using System.Collections.Generic;

namespace kata_conways_game_of_life
{
    public interface IGrid
    {
        void AddCellsToLocations();

        string Display();

        int GetLiveNeighboursCountFor(int row, int column);

    }
}