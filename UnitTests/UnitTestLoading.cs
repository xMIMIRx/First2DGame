using Xunit;
using ClassLibrary;

namespace ClassLibraryTests
{
    public class UnitTestLoading
    {
        [Fact]
        public void LoadMapTestNull()
        {
            // Arrange
            Loading loading = new Loading();

            // Act
            int[][] result = loading.LoadMap(-1);

            // Assert
            Assert.Null(result);
        }
    }
}
