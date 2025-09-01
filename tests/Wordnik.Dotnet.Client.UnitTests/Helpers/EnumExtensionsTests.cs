using System.ComponentModel.DataAnnotations;
using Wordnik.Dotnet.Client.Helpers;

namespace Wordnik.Dotnet.Client.UnitTests.Helpers
{
    public class EnumExtensionsTests
    {
        [Fact]
        public void ToApiString_WithDisplayAttribute_ReturnsCorrectApiValue()
        {
            // Arrange
            var value = TestEnumWithDisplay.ValueOne;

            // Act
            var apiString = value.ToApiString();

            // Assert
            Assert.Equal("api-value-one", apiString);
        }

        [Fact]
        public void ToApiString_WithMissingDisplayAttribute_ReturnsEnumToStringValue()
        {
            // Arrange
            var value = TestEnumWithDisplay.ValueThree;

            // Act
            var apiString = value.ToApiString();

            // Assert
            Assert.Equal("ValueThree", apiString);
        }

        [Fact]
        public void ToApiString_WithoutAnyDisplayAttribute_ReturnsEnumToStringValue()
        {
            // Arrange
            var value = TestEnumWithoutDisplay.SimpleValueOne;

            // Act
            var apiString = value.ToApiString();

            // Assert
            Assert.Equal("SimpleValueOne", apiString);
        }

        [Fact]
        public void ToApiString_InvalidEnumValue_ThrowsArgumentException()
        {
            // Arrange
            var invalidValue = (TestEnumWithDisplay)999;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => invalidValue.ToApiString());
            Assert.Equal($"The value '999' is not valid for enum '{typeof(TestEnumWithDisplay).Name}'.", exception.Message);
        }

        [Fact]
        public void ToApiString_ForAllValuesInEnumWithDisplay_ReturnsCorrectApiValues()
        {
            // Arrange & Act
            var apiStringOne = TestEnumWithDisplay.ValueOne.ToApiString();
            var apiStringTwo = TestEnumWithDisplay.ValueTwo.ToApiString();
            var apiStringThree = TestEnumWithDisplay.ValueThree.ToApiString();

            // Assert
            Assert.Equal("api-value-one", apiStringOne);
            Assert.Equal("api-value-two", apiStringTwo);
            Assert.Equal("ValueThree", apiStringThree);
        }

        [Fact]
        public void ToApiString_ForAllValuesInEnumWithoutDisplay_ReturnsToStringValues()
        {
            // Arrange & Act
            var apiStringOne = TestEnumWithoutDisplay.SimpleValueOne.ToApiString();
            var apiStringTwo = TestEnumWithoutDisplay.SimpleValueTwo.ToApiString();

            // Assert
            Assert.Equal("SimpleValueOne", apiStringOne);
            Assert.Equal("SimpleValueTwo", apiStringTwo);
        }

        private enum TestEnumWithDisplay
        {
            [Display(Name = "api-value-one")] ValueOne,
            [Display(Name = "api-value-two")] ValueTwo,
            ValueThree
        }

        private enum TestEnumWithoutDisplay
        {
            SimpleValueOne,
            SimpleValueTwo
        }
    }
}