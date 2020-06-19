using System.Collections.Generic;

namespace kata_conways_game_of_life.Models
{
    public interface IGrid
    {
        int NumberOfRows { get; }
        int NumberOfColumns { get; }
        void SetNeighboursForAllLocations();
        void AddDeadCellsToAllLocations();
        string Display();
        ILocation GetLocationAt(int rowNumber, int columnNumber);
        void SetNextCellStateForAllLocations();
        IEnumerable<ILocation> GetLocationsToKillCells();
        IEnumerable<ILocation> GetLocationsToReviveCells();
        bool HasLiveCells();
        bool ConfigurationIsChanging();
        
    }
}