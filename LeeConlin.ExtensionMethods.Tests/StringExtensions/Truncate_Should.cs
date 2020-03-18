using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class Truncate_Should
    {
        [Theory]
        [InlineData("abcdefghijklmnopqrstuvwxyz", 3, "abc")]
        [InlineData("abcdefghijklmnopqrstuvwxyz", 6, "abcdef")]
        public void Truncate_To_Character_Count_Exactly(string text, int maxLength, string expected)
        {
            var sut = text.Truncate(maxLength);
            sut.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("abc def ghi jkl mno pqr stu vwx yz", 3, "abc def ghi")]
        [InlineData("abc-def ghi jkl mno pqr stu vwx yz", 3, "abc-def ghi jkl")]
        [InlineData("abc def ghi jkl mno pqr stu vwx yz", 6, "abc def ghi jkl mno pqr")]
        public void Truncate_To_Word_Count_Exactly(string text, int maxLength, string expected)
        {
            var sut = text.Truncate(maxLength, StringTruncateStyle.MaxWords);
            sut.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("abc def ghi jkl mno pqr stu vwx yz", 10, "abc def")]
        [InlineData("abc def ghi jkl mno pqr stu vwx yz", 7, "abc def")]
        [InlineData("abc def ghi jkl mno pqr stu vwx yz", 8, "abc def")]
        [InlineData("abc def ghi jkl mno pqr stu vwx yz", 34, "abc def ghi jkl mno pqr stu vwx yz")]
        public void Truncate_To_Character_Count_At_Word_Break(string text, int maxLength, string expected)
        {
            var sut = text.Truncate(maxLength, StringTruncateStyle.MaxCharactersAtWordBoundry);
            sut.Should().Be(expected);
        }
    }
}