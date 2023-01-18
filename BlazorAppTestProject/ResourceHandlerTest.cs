using BlazorAppTestOgSikkerhed.Code;
using Microsoft.Extensions.Configuration;

namespace BlazorAppTestProject
{
    public class MyResourceHandlerTest
    {
        [Fact]
        public void TestResourceHandler()
        {
            // Arrange
            MyResourceHandler myResourceHandler = new MyResourceHandler();

            // Act
            bool isCreated = myResourceHandler.CreateTestFile();


            // Assert
            Assert.True(isCreated);

        }
    }
}