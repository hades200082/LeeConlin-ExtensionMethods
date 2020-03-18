using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.DateTimeExtensions
{
    public class IsWeekday_Should
    {
        public static IEnumerable<object[]> TestData => new List<object[]>
        { // We only really care to the day.
            new object[] { new DateTime(2020, 03, 16), true }, // Monday
            new object[] { new DateTime(2020, 03,17), true }, // Tuesday
            new object[] { new DateTime(2020, 03,18), true }, // Wednesday
            new object[] { new DateTime(2020, 03,19), true }, // Thursday
            new object[] { new DateTime(2020, 03,20), true }, // Friday
            new object[] { new DateTime(2020, 03,21), false }, // Saturday
            new object[] { new DateTime(2020, 03,22), false }, // Sunday
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Identify_Weekdays_Correctly(DateTime sut, bool expected)
        {
            sut.IsWeekday().Should().Be(expected);
        }
    }
}