using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.DoubleExtensions
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
        [InlineData(-0.7)]
        [InlineData(0.7)]
        public void Return_True_For_Truthy_Values(double sut)
        {
            sut.IsTruthy().Should().BeTrue();
        }
        
        [Fact]
        public void Return_False_For_Anything_Not_Truthy()
        {
            double sut = 0;
            sut.IsTruthy().Should().BeFalse();
        }
    }
}