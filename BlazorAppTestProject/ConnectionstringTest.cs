using Microsoft.Extensions.Configuration;

namespace BlazorAppTestProject
{
    public class ConnectionstringTest
    {
        [Fact]
        public void Connectionstring()
        {
            // Arrange
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Act
            var conn = config.GetConnectionString("DefaultConnection");

            // Assert
            Assert.Equal("Server=(localdb)\\mssqllocaldb;Database=LoginDB;Trusted_Connection=True;MultipleActiveResultSets=true", conn);

        }
    }
}