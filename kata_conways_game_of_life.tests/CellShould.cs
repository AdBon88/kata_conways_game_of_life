using System;
using kata_conways_game_of_life.Models;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class CellShould
    {
        public CellShould()
        {
            _sut = new Cell();
        }

        private readonly Cell _sut;
        [Fact]
        public void BeDeadOnCreation()
        {
            Assert.Equal(State.Dead, _sut.State);
        }

        [Fact]
        public void BeAliveWhenRevived()
        {
            _sut.Revive();
            
            Assert.Equal(State.Alive, _sut.State);
        }

        [Fact]
        public void BeDeadWhenKilled()
        {
            _sut.Revive();
            _sut.Die();
            
            Assert.Equal(State.Dead, _sut.State);
        }
        
    }
}