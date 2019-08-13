using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void Returns_Valid_value()
        {
            // Arrange
            IEnumerable<int> values = new List<int>() {1, 2, 4, 9, 12};

            // Act
            IEnumerable<int> result = values.Where(x => x < 10).Select(x => x * 2);

            // Asert
            Assert.Contains(2, result);
            Assert.Contains(4, result);
            Assert.Contains(8, result);
            Assert.Contains(18, result);
        }
        
        [Fact]
        public void Throws_exception()
        {
            // Arrange
            IEnumerable<int> values = new List<int>() {1, 2, 4, 9, 12};

            // Act
            IEnumerable<int> result = values.Where(x => x < 10).Select(x => x * 2);

            // Act & Asert
            Assert.Throws<InvalidOperationException>(() => values.Single(x => x < 5));
        }

        private int Execute(int i)
        {
            return i * 2;
        }
    }
}
