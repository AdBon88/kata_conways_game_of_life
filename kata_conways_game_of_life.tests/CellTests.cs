using System;
using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class CellTests
    {
        [Fact]
        public void BeDeadOnCreation()
        {
            var sut = new Cell();
            
            Assert.Equal(State.Dead, sut.State);
        }
        
    }
}