using System.Collections.Generic;

namespace kata_conways_game_of_life.Models
{
    public interface IGrid
    {
        int NumberOfRows { get; }
        int NumberOfColumns { get; }
        void AddCellsToLocations();
        string Display();
        ILocation GetLocationAt(int rowNumber, int columnNumber);
        void SetNextCellStateForAllLocations();
        bool AreAllCellsDead();
        IEnumerable<ILocation> GetLocationsToKillCells();
        IEnumerable<ILocation> GetLocationsToReviveCells();
        
    }
}