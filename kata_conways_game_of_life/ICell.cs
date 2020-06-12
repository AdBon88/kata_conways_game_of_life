namespace kata_conways_game_of_life
{
    public interface ICell
    {
        State State { get;}
        
        string GetDisplay();

        void Die();

        void Revive();
    }
}