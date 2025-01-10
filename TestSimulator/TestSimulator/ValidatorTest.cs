using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Simulator.Tests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(5, 1, 10, 5)]   
        [InlineData(0, 1, 10, 1)]   
        [InlineData(15, 1, 10, 10)] 
        public void Limiter_ShouldReturnValueWithinRange(int value, int min, int max, int expected)
        {
            
            int result = Validator.Limiter(value, min, max);

            
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("", 3, 6, '-', "Unknown")]                
        [InlineData(null, 3, 6, '-', "Unknown")]             
        [InlineData("ab", 3, 6, '-', "Ab-")]                
        [InlineData("abcdef", 3, 6, '-', "Abcdef")]        
        [InlineData("abcdefghi", 3, 6, '-', "Abcdef")]      
        [InlineData("   abc   ", 3, 6, '-', "Abc")]       
        [InlineData("a", 1, 1, '-', "A")]                  
        public void Shortener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
        {
            
            string result = Validator.Shortener(value, min, max, placeholder);

            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Shortener_NullOrWhiteSpaceInput_ShouldReturnUnknown()
        {
            
            string input = null;
            int min = 3, max = 6;
            char placeholder = '-';

            
            string result = Validator.Shortener(input, min, max, placeholder);

            
            Assert.Equal("Unknown", result);
        }

        [Fact]
        public void Shortener_LowercaseFirstLetter_ShouldCapitalizeFirstLetter()
        {
            
            string input = "test";
            int min = 3, max = 10;
            char placeholder = '-';

           
            string result = Validator.Shortener(input, min, max, placeholder);

            
            Assert.Equal("Test", result);
        }
    }
}
