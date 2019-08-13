using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FastShotter.Tests
{
    public class Sumator
    {
        public int Sum(int a, int b) => a + b;
    }

    public class SumatorTest
    {
        private Sumator Sumator { get; set; }
        public SumatorTest()
        {
            Sumator = new Sumator();
        }

        [Fact]
        public void SumTest()
        {
            // Arrange
            const int a = 3;
            const int b = 5;

            // Act
            var response = Execute2(a, b);

            // Assert
            Assert.True(response == 8);
        }

        [Fact]
        public void Test333()
        {
            const int a = 10;
            const int b = 4;

            // Act
            var response = ExecuteString(a, b);

            // Assert
            Assert.Contains("10", response);
            Assert.Contains("4", response);
        }

        [Fact]
        public void Test222()
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

        private int Execute2(int a, int b) => Sumator.Sum(a, b);
        private IEnumerable<string> ExecuteString(int a, int b) => new List<string>() { a.ToString(), b.ToString() };
    }
}
