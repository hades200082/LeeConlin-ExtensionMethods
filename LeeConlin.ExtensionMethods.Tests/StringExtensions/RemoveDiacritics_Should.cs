using FluentAssertions;
using Xunit;

namespace LeeConlin.ExtensionMethods.Tests.StringExtensions
{
    public class RemoveDiacritics_Should
    {
        [Theory]
        [InlineData("Altés", "Altes")]
        [InlineData("Thérèse", "Therese")]
        public void Correctly_Remove_Diacritics(string input, string expected)
        {
            var sut = input.RemoveDiacritics();
            sut.Should().Be(expected);
        }
    }
}