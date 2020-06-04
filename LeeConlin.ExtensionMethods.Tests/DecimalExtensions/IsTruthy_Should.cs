using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.DecimalExtensions
{
    public class IsTruthy_Should
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(999)]
        [InlineData(-1)]
        [InlineData(-1.7)]
        [InlineData(1.7)]
        public void Return_True_For_Truthy_Values(decimal sut)
        {
            sut.IsTruthy().Should().BeTrue();
        }
        
        [Fact]
        public void Return_False_For_Anything_Not_Truthy()
        {
            decimal sut = 0;
            sut.IsTruthy().Should().BeFalse();
        }
    }
}