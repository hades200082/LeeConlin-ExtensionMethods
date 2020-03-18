using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class ToBase64_Should
    {
        public static IEnumerable<object[]> EncodeTextCorrectlyData => new List<object[]>
        {
            new object[] {"The quick brown fox", null, "VGhlIHF1aWNrIGJyb3duIGZveA=="},
            new object[]
            {
                "The quick brown fox", Encoding.UTF32,
                "VAAAAGgAAABlAAAAIAAAAHEAAAB1AAAAaQAAAGMAAABrAAAAIAAAAGIAAAByAAAAbwAAAHcAAABuAAAAIAAAAGYAAABvAAAAeAAAAA=="
            }
        };
            
        [Theory]
        [MemberData(nameof(EncodeTextCorrectlyData))]
        public void Encode_Text_Correctly(string input, Encoding encoding, string expected)
        {
            var sut = input.ToBase64(encoding);
            sut.Should().Be(expected);
        }
    }
}