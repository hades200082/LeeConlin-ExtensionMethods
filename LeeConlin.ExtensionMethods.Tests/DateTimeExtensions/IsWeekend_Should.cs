using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.DateTimeExtensions
{
    public class IsWeekend_Should
    {
        public static IEnumerable<object[]> TestData => new List<object[]>
        { // We only really care to the day.
            new object[] { new DateTime(2020, 03, 16), false }, // Monday
            new object[] { new DateTime(2020, 03,17), false }, // Tuesday
            new object[] { new DateTime(2020, 03,18), false }, // Wednesday
            new object[] { new DateTime(2020, 03,19), false }, // Thursday
            new object[] { new DateTime(2020, 03,20), false }, // Friday
            new object[] { new DateTime(2020, 03,21), true }, // Saturday
            new object[] { new DateTime(2020, 03,22), true }, // Sunday
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Identify_Weekends_Correctly(DateTime sut, bool expected)
        {
            sut.IsWeekend().Should().Be(expected);
        }
    }
}