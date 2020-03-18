using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class NthIndexOf_Should
    {
        [Theory]
        [InlineData("abcabc", 'a', 1, 0)]
        [InlineData("abcabc", 'a', 2, 3)]
        [InlineData("abcabc", 'b', 1, 1)]
        [InlineData("abcabc", 'b', 2, 4)]
        [InlineData("abcabc", 'c', 1, 2)]
        [InlineData("abcabc", 'c', 2, 5)]
        public void Return_The_Correct_Index(string text, char ch, int n, int expected)
        {
            var sut = text.NthIndexOf(ch, n);
            sut.Should().Be(expected);
        }
    }
}