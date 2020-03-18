using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.DateTimeExtensions
{
    public class ToAgeInYears_Should
    {
        public static IEnumerable<object[]> TestData => new List<object[]>
        { // We only really care to the day.
            new object[] { DateTime.Now.AddYears(-12), 12 },
            new object[] { DateTime.Now.AddYears(-12).AddDays(1), 11 },
            new object[] { DateTime.Now.AddYears(-12).AddHours(1), 12 },
            new object[] { DateTime.Now.AddYears(-12).AddMinutes(1), 12 },
            new object[] { DateTime.Now.AddYears(-12).AddSeconds(1), 12 },
            new object[] { DateTime.Now.AddYears(-12).AddMilliseconds(1), 12 },
            new object[] { DateTime.Now.AddYears(-12).AddMicroseconds(1), 12 }
        };
        
        [Theory]
        [MemberData(nameof(TestData))]
        public void Return_Age_Correctly(DateTime sut, int expected)
        {
            sut.ToAgeInYears().Should().Be(expected);
        }
        
    }
}