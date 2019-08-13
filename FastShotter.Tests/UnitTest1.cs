using System;
using Xunit;

namespace FastShotter.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            int i = 10;
            
            // Act
            int result = Execute(5);

            // Assert
            Assert.True(result == 10, "result is true");
        }

        private int Execute(int i)
        {
            return i * 2;
        }
    }
}
