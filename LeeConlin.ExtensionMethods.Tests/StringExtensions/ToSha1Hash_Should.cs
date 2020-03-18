using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class ToSha1Hash_Should
    {
        [Theory]
        [InlineData("test", true, "A94A8FE5CCB19BA61C4C0873D391E987982FBBD3")]
        [InlineData("test", false, "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")]
        public void Create_Correct_Sha1_Hash_For_Input_Text(string input, bool uppercase, string expected)
        {
            var sut = input.ToSha1Hash(uppercase);
            sut.Should().Be(expected);
        }
    }
}