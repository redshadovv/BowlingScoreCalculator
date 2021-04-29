using BowlingScoreCalculator.Domain;
using FluentAssertions;
using Xunit;

namespace BowlingScoreCalculatorTests.Unit
{
    public class FrameTests
    {
        [Theory]
        [InlineData(3, 4, 7)]
        [InlineData(7, 3, 15)]
        [InlineData(10, 0, 19)]
        public void FrameCalculatesScore(int roll1, int roll2, int expected)
        {
            var sut = new Frame(1, new []{ roll1, roll2 });

            var result = sut.CalculateScore(5, 4);

            result.Should().Be(expected);
        }
    }
}
