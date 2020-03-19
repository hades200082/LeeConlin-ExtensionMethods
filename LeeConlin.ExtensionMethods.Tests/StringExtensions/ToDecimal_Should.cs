using System.Collections.Generic;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class ToDecimal_Should
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("6..2")]
        [InlineData("ab6")]
        [InlineData("6a")]
        public void Return_Zero_For_Non_Decimal_Strings(string sut)
        {
            sut.ToInt().Should().Be(0);
        }

        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[] {"6", 6m},
            new object[] {"-6", -6m},
            new object[] {"6.55672", 6.55672m},
            new object[] {"-6.55672", -6.55672m},
            new object[] {"100", 100m},
            new object[] {"-100", -100m},
            new object[] {"100.55672", 100.55672m},
            new object[] {"-100.55672", -100.55672m},
            new object[] {"1,000", 1000m},
            new object[] {"-1,000", -1000m},
            new object[] {"1,000.55672", 1000.55672m},
            new object[] {"-1,000.55672", -1000.55672m},
            new object[] {"£6", 6m},
            new object[] {"-£6", -6m},
            new object[] {"£6.55672", 6.55672m},
            new object[] {"-£6.55672", -6.55672m},
            new object[] {"£100", 100m},
            new object[] {"-£100", -100m},
            new object[] {"£100.55672", 100.55672m},
            new object[] {"-£100.55672", -100.55672m},
            new object[] {"£1,000", 1000m},
            new object[] {"-£1,000", -1000m},
            new object[] {"£1,000.55672", 1000.55672m},
            new object[] {"-£1,000.55672", -1000.55672m},
        };
        
        [Theory]
        [MemberData(nameof(TestData))]
        public void Return_Correct_Decimal_Value_For_Decimal_Strings(string sut, decimal expected)
        {
            sut.ToDecimal().Should().Be(expected, "Current culture is {0}", Thread.CurrentThread.CurrentCulture.Name);
        }
    }
}