using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class IsTruthy_Should
    {
        [Theory]
        [InlineData("Yes")]
        [InlineData("yes")]
        [InlineData("yEs")]
        [InlineData("YES")]
        [InlineData("Yep")]
        [InlineData("true")]
        [InlineData("TRUE")]
        [InlineData("True")]
        [InlineData("tRue")]
        [InlineData("1")]
        [InlineData("1.0")]
        [InlineData("1.00000")]
        public void Return_True_For_Truthy_Values(string sut)
        {
            sut.IsTruthy().Should().BeTrue();
        }
        
        [Theory]
        [InlineData("False")]
        [InlineData("false")]
        [InlineData("fAlse")]
        [InlineData("FALSE")]
        [InlineData("no")]
        [InlineData("NO")]
        [InlineData("No")]
        [InlineData("Nope")]
        [InlineData("0")]
        [InlineData("0.0")]
        [InlineData("0.00000")]
        [InlineData("abc")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Return_False_For_Anything_Not_Truthy(string sut)
        {
            sut.IsTruthy().Should().BeFalse();
        }
    }
}