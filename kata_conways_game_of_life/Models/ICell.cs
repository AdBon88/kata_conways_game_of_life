namespace kata_conways_game_of_life.Models
{
    public interface ICell
    {
        State State { get;}
        
        void Die();

        void Revive();
    }
}