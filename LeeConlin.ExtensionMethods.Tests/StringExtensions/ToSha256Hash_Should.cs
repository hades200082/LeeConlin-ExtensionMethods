using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class ToSha256Hash_Should
    {
        [Theory]
        [InlineData("test", true, "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08")]
        [InlineData("test", false, "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08")]
        public void Create_Correct_Sha256_Hash_For_Input_Text(string input, bool uppercase, string expected)
        {
            var sut = input.ToSha256Hash(uppercase);
            sut.Should().Be(expected);
        }
    }
}