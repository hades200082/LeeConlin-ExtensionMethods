using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.BoolExtensions
{
    public class ToYesNo_Should
    {
        [Fact]
        public void Return_Yes_For_True()
        {
            var sut = true;
            sut.ToYesNo().Should().Be("Yes");
        }
        
        [Fact]
        public void Return_No_For_False()
        {
            var sut = false;
            sut.ToYesNo().Should().Be("No");
        }
    }
}