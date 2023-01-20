using Bunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppTestProject
{
    public class PerformanceTest
    {
        private const int N = 10000;

        [Fact]
        public void TestPerformance()
        {
            // Arrange
            using var context = new TestContext();



            // Act
            var perfTest = context.

            // Assert

        }
    }
}
