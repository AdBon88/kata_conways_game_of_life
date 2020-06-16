using System.Collections.Generic;

namespace kata_conways_game_of_life
{
    public interface IGrid
    {
        void AddCellsToLocations();

        string Display();
        ILocation GetLocationAt(int rowNumber, int columnNumber);

        int GetLiveNeighboursCountFor(ILocation location);

        void SetNextCellStateForAllLocations();

        bool AreAllCellsDead();
        IEnumerable<ILocation> GetLocationsToKillCells();
        IEnumerable<ILocation> GetLocationsToReviveCells();
        // void KillCells(IEnumerable<ILocation> locationsForCellDeath);
        // void ReviveCells(IEnumerable<ILocation> locationsToReviveCells);

    }
}