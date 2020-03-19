using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class ToInt_Should
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("6.2")]
        [InlineData("ab6")]
        [InlineData("6a")]
        [InlineData("$6")]
        public void Return_Zero_For_Non_Integer_Strings(string sut)
        {
            sut.ToInt().Should().Be(0);
        }
        
        [Theory]
        [InlineData("6", 6)]
        [InlineData("-6", -6)]
        [InlineData("100", 100)]
        [InlineData("-100", -100)]
        [InlineData("1,000", 1000)]
        [InlineData("-1,000", -1000)]
        public void Return_Correct_Int_Value_For_Integer_Strings(string sut, int expected)
        {
            sut.ToInt().Should().Be(expected);
        }
    }
}