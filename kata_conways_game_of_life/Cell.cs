using System;
using System.Collections.Generic;

namespace kata_conways_game_of_life
{
    public class Cell : ICell
    {
        public Cell()
        {
            State = State.Dead;
        }

        public State State { get; private set; }
        
        public void Die()
        {
            State = State.Dead;
        }

        public void Revive()
        {
            State = State.Alive;
        }
        
    }
}