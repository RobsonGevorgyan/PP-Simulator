using Simulator;
using Xunit;

namespace Simulator.Tests
{
    public class PointTests
    {
        [Fact]
        public void Constructor_ShouldSetCoordinates()
        {
           
            int x = 5;
            int y = 10;

            
            var point = new Point(x, y);

            
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        [Theory]
        [InlineData(Direction.Left, -1, 0)]
        [InlineData(Direction.Right, 1, 0)]
        [InlineData(Direction.Up, 0, 1)]
        [InlineData(Direction.Down, 0, -1)]
        public void Next_ShouldReturnCorrectPoint(Direction direction, int deltaX, int deltaY)
        {
            
            var start = new Point(0, 0);

            
            var result = start.Next(direction);

           
            Assert.Equal(new Point(0 + deltaX, 0 + deltaY), result);
        }

        [Fact]
        public void Next_InvalidDirection_ShouldReturnSamePoint()
        {
            
            var start = new Point(0, 0);
            var invalidDirection = (Direction)(-1); 

            
            var result = start.Next(invalidDirection);

            
            Assert.Equal(start, result);
        }

        [Theory]
        [InlineData(Direction.Left, -1, 1)]
        [InlineData(Direction.Right, 1, -1)]
        [InlineData(Direction.Up, 1, 1)]
        [InlineData(Direction.Down, -1, -1)]
        public void NextDiagonal_ShouldReturnCorrectPoint(Direction direction, int deltaX, int deltaY)
        {
            
            var start = new Point(0, 0);

            
            var result = start.NextDiagonal(direction);

            
            Assert.Equal(new Point(0 + deltaX, 0 + deltaY), result);
        }

        [Fact]
        public void NextDiagonal_InvalidDirection_ShouldReturnSamePoint()
        {
            
            var start = new Point(0, 0);
            var invalidDirection = (Direction)(-1); // Assuming invalid direction

            
            var result = start.NextDiagonal(invalidDirection);

           
            Assert.Equal(start, result);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedString()
        {
            
            var point = new Point(4, 2);

            
            string result = point.ToString();

            
            Assert.Equal("(4, 2)", result);
        }
    }
}
