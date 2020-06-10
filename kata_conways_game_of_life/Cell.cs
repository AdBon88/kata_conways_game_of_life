using System;
using System.Collections.Generic;

namespace kata_conways_game_of_life
{
    public class Cell
    {
        public Cell()
        {
            State = State.Dead;
        }
        
        public State State;

        public char GetDisplay()
        {
            return State == State.Dead ? '◻' : '◼';
        }


    }
}