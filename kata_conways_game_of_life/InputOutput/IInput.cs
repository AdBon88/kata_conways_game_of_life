namespace kata_conways_game_of_life.InputOutput
{
    public interface IInput
    {
        string GetGridDimension(string dimension);
        string GetStartingLiveLocation();
        string GetAdditionalStartingLocations();
        
    }
}