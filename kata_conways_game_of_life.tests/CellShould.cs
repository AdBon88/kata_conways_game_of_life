using System;
using kata_conways_game_of_life.Models;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class CellShould
    {
        [Fact]
        public void BeDeadOnCreation()
        {
            var sut = new Cell();
            
            Assert.Equal(State.Dead, sut.State);
        }

        [Fact]
        public void BeAliveWhenRevived()
        {
            var sut = new Cell();
            sut.Revive();
            
            Assert.Equal(State.Alive, sut.State);
        }

        [Fact]
        public void BeDeadWhenKilled()
        {
            var sut = new Cell();
            sut.Revive();
            sut.Die();
            
            Assert.Equal(State.Dead, sut.State);
        }
        
    }
}