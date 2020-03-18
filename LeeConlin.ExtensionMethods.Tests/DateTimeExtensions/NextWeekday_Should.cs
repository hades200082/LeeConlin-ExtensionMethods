using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.DateTimeExtensions
{
    public class NextWeekday_Should
    {
        public static IEnumerable<object[]> TestData => new List<object[]>
        { // We only really care to the day.
            new object[] { new DateTime(2020, 03, 16), new DateTime(2020, 03,17) }, // Monday
            new object[] { new DateTime(2020, 03,17), new DateTime(2020, 03,18) }, // Tuesday
            new object[] { new DateTime(2020, 03,18), new DateTime(2020, 03,19) }, // Wednesday
            new object[] { new DateTime(2020, 03,19), new DateTime(2020, 03,20) }, // Thursday
            new object[] { new DateTime(2020, 03,20), new DateTime(2020, 03,23) }, // Friday
            new object[] { new DateTime(2020, 03,21), new DateTime(2020, 03,23) }, // Saturday
            new object[] { new DateTime(2020, 03,22), new DateTime(2020, 03,23) }, // Sunday
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Identify_Next_Weekday_Correctly(DateTime sut, DateTime expected)
        {
            sut.NextWeekday().Date.Should().Be(expected.Date);
        }
    }
}