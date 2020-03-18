using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class ToMd5Hash_Should
    {
        [Theory]
        [InlineData("test", true, "098F6BCD4621D373CADE4E832627B4F6")]
        [InlineData("test", false, "098f6bcd4621d373cade4e832627b4f6")]
        public void Create_Correct_Md5_Hash_For_Input_Text(string input, bool uppercase, string expected)
        {
            var sut = input.ToMd5Hash(uppercase);
            sut.Should().Be(expected);
        }
    }
}