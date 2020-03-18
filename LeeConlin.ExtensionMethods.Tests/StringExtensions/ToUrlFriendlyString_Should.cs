using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class ToUrlFriendlyString_Should
    {
        [Theory]
        [InlineData("TEST", "test")]
        [InlineData("TeSt", "test")]
        [InlineData("TeSt001", "test001")]
        public void Return_Lowercase_Only(string input, string expected)
        {
            var sut = input.ToUrlFriendlyString();
            sut.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("test one", "test-one")]
        [InlineData("test@two", "test-two")]
        [InlineData("test@@@three", "test-three")]
        public void Correctly_Replace_Special_Characters_And_Spaces_With_Hyphens(string input, string expected)
        {
            var sut = input.ToUrlFriendlyString();
            sut.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("Altés", "altes")]
        [InlineData("Thérèse", "therese")]
        public void Correctly_Remove_Diacritics(string input, string expected)
        {
            var sut = input.ToUrlFriendlyString();
            sut.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("test----test", "test-test")]
        [InlineData("test-@#-test", "test-test")]
        [InlineData("test~'$-test", "test-test")]
        [InlineData("test!\"£$%^&*()test", "test-test")]
        [InlineData("!\"£$%^&*()test!\"£$%^&*()test", "test-test")]
        public void Only_Place_One_Hyphen_Between_Words(string input, string expected)
        {
            var sut = input.ToUrlFriendlyString();
            sut.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("test----", "test")]
        [InlineData("----test", "test")]
        [InlineData("test-@#-", "test")]
        [InlineData("-@#-test", "test")]
        [InlineData("test~'$-", "test")]
        [InlineData("~'$-test", "test")]
        [InlineData("test!\"£$%^&*()", "test")]
        [InlineData("!\"£$%^&*()test", "test")]
        [InlineData("!\"£$%^&*()test!\"£$%^&*()", "test")]
        public void Remove_Trailing_And_Leading_Hyphens(string input, string expected)
        {
            var sut = input.ToUrlFriendlyString();
            sut.Should().Be(expected);
        }
    }
}