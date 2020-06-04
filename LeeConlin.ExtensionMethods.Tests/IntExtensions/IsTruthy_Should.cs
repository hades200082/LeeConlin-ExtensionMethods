using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.IntExtensions
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
        public void Return_True_For_Truthy_Values(int sut)
        {
            sut.IsTruthy().Should().BeTrue();
        }
        
        [Fact]
        public void Return_False_For_Anything_Not_Truthy()
        {
            int sut = 0;
            sut.IsTruthy().Should().BeFalse();
        }
    }
}