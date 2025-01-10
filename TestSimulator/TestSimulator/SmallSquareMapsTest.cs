using System;
using System.Drawing;
using Simulator.Maps;
using Xunit;

namespace Simulator.Tests
{
    public class SmallSquareMapTests
    {
        [Fact]
        public void Constructor_ValidSize_ShouldSetSize()
        {
            // Arrange
            int validSize = 10;

            // Act
            var map = new SmallSquareMap(validSize);

            // Assert
            Assert.Equal(validSize, map.Size);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(21)]
        public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int invalidSize)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(invalidSize));
        }

        [Theory]
        [InlineData(5, 5, true)]
        [InlineData(-1, 5, false)]
        [InlineData(5, -1, false)]
        [InlineData(21, 21, false)]
        public void Exist_ShouldReturnCorrectResult(int x, int y, bool expected)
        {
            
            var map = new SmallSquareMap(10);
            var point = new Point(x, y);

            
            bool result = map.Exist(point);

            
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Next_ValidMove_ShouldReturnNextPoint()
        {
            
            var map = new SmallSquareMap(10);
            var start = new Point(5, 5);
            var direction = Direction.Up; 

            
            var result = map.Next(start, direction);

            
            Assert.NotEqual(start, result); 
        }

        [Fact]
        public void Next_InvalidMove_ShouldReturnSamePoint()
        {
            
            var map = new SmallSquareMap(10);
            var start = new Point(0, 0);
            var direction = Direction.Left; 

           
            var result = map.Next(start, direction);

            
            Assert.Equal(start, result);
        }

        [Fact]
        public void NextDiagonal_ValidMove_ShouldReturnNextPoint()
        {
            
            var map = new SmallSquareMap(10);
            var start = new Point(5, 5);
            var direction = Direction.Right; 

            
            var result = map.NextDiagonal(start, direction);


            Assert.NotEqual(start, result);
        }

        [Fact]
        public void NextDiagonal_InvalidMove_ShouldReturnSamePoint()
        {
            
            var map = new SmallSquareMap(10);
            var start = new Point(0, 0);
            var direction = Direction.Down;

            
            var result = map.NextDiagonal(start, direction);

           
            Assert.Equal(start, result);
        }
    }
}
