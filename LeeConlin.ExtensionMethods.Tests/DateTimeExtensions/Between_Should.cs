using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.DateTimeExtensions
{
    public class Between_Should
    {
        [Fact]
        public void Return_True_For_Test_Equals_Start_Of_Range()
        {
            var sut = new DateTime(1982, 01, 26, 13, 16, 05);
            
            var start = new DateTime(1982, 01, 26, 13, 16, 05);
            var end = DateTime.Now;

            sut.Between(start, end).Should().Be(true);
        }
        [Fact]
        public void Return_True_For_Test_Equals_End_Of_Range()
        {
            var sut = new DateTime(1982, 01, 26, 13, 16, 05);
            
            var start = DateTime.Now;
            var end = new DateTime(1982, 01, 26, 13, 16, 05);

            sut.Between(start, end).Should().Be(true);
        }

        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[]
            { // 1 second inside
                new DateTime(2020,1,1,00,00, 01),
                new DateTime(2020,1,1,00,00, 00), 
                new DateTime(2020,1,1,00,00,02),
                true
            },
            new object[]
            { // 1 second outside
                new DateTime(2020,1,1,00,00, 03),
                new DateTime(2020,1,1,00,00, 00), 
                new DateTime(2020,1,1,00,00,02),
                false
            } ,
            new object[]
            { // Feb 29 in leapyear between Feb 28 and Mar 1
                new DateTime(2020,2,29,00,00, 00),
                new DateTime(2020,2,28,00,00, 00), 
                new DateTime(2020,3,1,00,00,00),
                true
            } ,
            new object[]
            { // Across the millennium
                new DateTime(2000,1,1,00,00, 00),
                new DateTime(1999,1,1,00,00, 00), 
                new DateTime(2001,1,1,00,00,00),
                true
            } 
        };
        
        [Theory]
        [MemberData(nameof(TestData))]
        public void Return_True_For_Test_Between_Start_And_End_Of_Range(DateTime sut, DateTime start, DateTime end, bool expected)
        {
            sut.Between(start, end).Should().Be(expected);
        }
    }
}