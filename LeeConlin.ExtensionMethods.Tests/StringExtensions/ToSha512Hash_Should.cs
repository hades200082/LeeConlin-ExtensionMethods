using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class ToSha512Hash_Should
    {
        [Theory]
        [InlineData("test", true, "EE26B0DD4AF7E749AA1A8EE3C10AE9923F618980772E473F8819A5D4940E0DB27AC185F8A0E1D5F84F88BC887FD67B143732C304CC5FA9AD8E6F57F50028A8FF")]
        [InlineData("test", false, "ee26b0dd4af7e749aa1a8ee3c10ae9923f618980772e473f8819a5d4940e0db27ac185f8a0e1d5f84f88bc887fd67b143732c304cc5fa9ad8e6f57f50028a8ff")]
        public void Create_Correct_Sha512_Hash_For_Input_Text(string input, bool uppercase, string expected)
        {
            var sut = input.ToSha512Hash(uppercase);
            sut.Should().Be(expected);
        }
    }
}