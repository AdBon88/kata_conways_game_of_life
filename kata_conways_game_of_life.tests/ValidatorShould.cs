using Xunit;

namespace kata_conways_game_of_life.tests
{
    public class ValidatorShould
    {
        [Fact]
        public void IndicateIfStringCoordinatesCanBeParsedToIntegers()
        {
            const string coordinates1 = "2, 2";
            const string coordinates2 = "a, 3";
            
            var actual1 = Validator.AreCoordinatesValidNumbers(coordinates1);
            var actual2 = Validator.AreCoordinatesValidNumbers(coordinates2);
            
            Assert.True(actual1);
            Assert.False(actual2);
        }
 
        
    }
}