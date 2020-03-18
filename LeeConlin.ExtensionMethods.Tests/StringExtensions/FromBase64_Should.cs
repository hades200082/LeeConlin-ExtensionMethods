using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class FromBase64_Should
    {
        public static IEnumerable<object[]> EncodeTextCorrectlyData => new List<object[]>
        {
            new object[] {"VGhlIHF1aWNrIGJyb3duIGZveA==", null, "The quick brown fox"},
            new object[]
            {
                "VAAAAGgAAABlAAAAIAAAAHEAAAB1AAAAaQAAAGMAAABrAAAAIAAAAGIAAAByAAAAbwAAAHcAAABuAAAAIAAAAGYAAABvAAAAeAAAAA==",
                Encoding.UTF32,
                "The quick brown fox"
            }
        };
            
        [Theory]
        [MemberData(nameof(EncodeTextCorrectlyData))]
        public void Encode_Text_Correctly(string input, Encoding encoding, string expected)
        {
            var sut = input.FromBase64(encoding);
            sut.Should().Be(expected);
        }
    }
}