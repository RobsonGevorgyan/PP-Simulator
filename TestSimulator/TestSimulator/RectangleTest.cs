using System;
using Simulator;
using Xunit;

namespace Simulator.Tests
{
    public class RectangleTests
    {
        [Fact]
        public void Constructor_InvalidCoordinates_ShouldThrowArgumentException()
        {
           
            int x1 = 3, y1 = 5, x2 = 3, y2 = 8; 

          
            Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
        }

        [Fact]
        public void Constructor_WithPoints_ShouldCreateRectangle()
        {
            
            var p1 = new Point(1, 2);
            var p2 = new Point(4, 6);

            
            var rectangle = new Rectangle(p1, p2);

          
            Assert.NotNull(rectangle);
        }

        [Theory]
        [InlineData(2, 3, true)]  
        [InlineData(1, 2, true)]  
        [InlineData(0, 0, false)] 
        [InlineData(5, 7, false)] 
        public void Contains_ShouldReturnCorrectResult(int x, int y, bool expected)
        {
          
            var rectangle = new Rectangle(1, 2, 4, 6);
            var point = new Point(x, y);

           
            bool result = rectangle.Contains(point);

           
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedString()
        {
            
            var rectangle = new Rectangle(1, 2, 4, 6);

            string result = rectangle.ToString();

           
            Assert.Equal("(1, 2):(4, 6)", result);
        }
    }
}
