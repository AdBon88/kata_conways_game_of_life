using System;
using System.Runtime.Serialization;
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
        
        [Fact]
        public void DisplayAsABlankSquareIfDead()
        {
            var sut = new Cell();
            Assert.Equal("[ ]", sut.GetDisplay());
        }

        [Fact]
        public void DisplayAsFilledSquareIfAlive()
        {
            var sut = new Cell {State = State.Alive};

            Assert.Equal("[#]", sut.GetDisplay());
        }
    }
}