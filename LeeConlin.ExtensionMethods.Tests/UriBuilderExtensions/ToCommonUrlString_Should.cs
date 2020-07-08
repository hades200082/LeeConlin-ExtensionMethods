using System;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.UriBuilderExtensions
{
    public class ToCommonUrlString_Should
    {
        [Theory]
        [InlineData("https://www.google.co.uk", "https://www.google.co.uk/")]
        [InlineData("http://www.google.co.uk", "http://www.google.co.uk/")]
        [InlineData("https://www.google.co.uk:44353", "https://www.google.co.uk:44353/")]
        [InlineData("http://www.google.co.uk:8080", "http://www.google.co.uk:8080/")]
        public void CorrectlyRemovePortNumbersForKnownSchemes(string testUrl, string expected)
        {
            var sut = new UriBuilder(testUrl);

            sut.ToCommonUrlString().Should().Be(expected);
        }
    }
}