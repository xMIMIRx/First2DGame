using First2DGame;

namespace UnitTests
{
    public class UnitTestGame
    {
        private readonly int[][] map = new int[][] {
            new int[] { 1, 1, 1, 1 },
            new int[] { 1, 2, 0, 1 },
            new int[] { 1, 0, 3, 1 },
            new int[] { 1, 1, 1, 1 },
        };

        [Theory]
        [InlineData(0, 0, false)]
        [InlineData(1, 0, false)]
        [InlineData(2, 0, false)]
        [InlineData(3, 0, false)]

        [InlineData(0, 1, false)]
        [InlineData(1, 1, true)] // ponieważjest różny od 1
        [InlineData(2, 1, true)] // ponieważjest różny od 1
        [InlineData(3, 1, false)]

        [InlineData(0, 2, false)]
        [InlineData(1, 2, true)] // ponieważjest różny od 1
        [InlineData(2, 2, true)] // ponieważjest różny od 1
        [InlineData(3, 2, false)]

        [InlineData(0, 3, false)]
        [InlineData(1, 3, false)]
        [InlineData(2, 3, false)]
        [InlineData(3, 3, false)]
        public void PlayerCanMove_Test(int x, int y, bool expected)
        {
            // Arrange
            var game = new Game(map);
            // Act
            var result = game.PlayerCanMove(x, y);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}
