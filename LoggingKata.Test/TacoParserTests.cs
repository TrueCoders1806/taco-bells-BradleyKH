using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort... (Free trial * Add to Cart for a full POI info)")]
        [InlineData("0,0,name")]
        [InlineData("-89.99,-89.989,name name name name name ")]
        [InlineData("50,   60,    name...")]
        public void ShouldParse(string str)
        {
            // Arrange
            var parser = new TacoParser();

            // Act
            var value = parser.Parse(str);

            // Assert
            Assert.NotNull(value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1, something")]
        [InlineData("1, 2, 3, something")]
        [InlineData("hickory, dickory, dock")]
        [InlineData("91, -91, hi mom")]
        public void ShouldFailParse(string str)
        {
            // Arrange
            var parser = new TacoParser();

            // Act
            var value = parser.Parse(str);

            // Assert
            Assert.Null(value);
        }
    }
}
