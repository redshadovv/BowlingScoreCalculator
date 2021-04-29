using BowlingScoreCalculator.Domain;
using FluentAssertions;
using Xunit;

namespace BowlingScoreCalculatorTests.Unit
{
    public class ScoreboardTests
    {
        [Theory]
        [InlineData(5, 3, 2, 0, 10)]
        [InlineData(3, 7, 6, 4, 26)]
        [InlineData(3, 7, 2, 0, 14)]
        [InlineData(10, 0, 2, 0, 14)]
        [InlineData(10, 0, 2, 4, 22)]
        public void ScoreboardCalculatesRegularFrameScoresCorrectly(int roll1, int roll2, int roll3, int roll4, int expected)
        {
            int[][] frames = new[]
            {
                new[]{ roll1, roll2},
                new[]{ roll3, roll4},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
            };
            var sut = new Scoreboard(frames);

            var result = sut.CalculateFinalScore();

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(5, 3, 0, 8)]
        [InlineData(5, 5, 2, 12)]
        [InlineData(10, 5, 7, 22)]
        [InlineData(10, 10, 10, 30)]
        public void ScoreboardCalculatesFrame10ScoresCorrectly(int roll1, int roll2, int roll3, int expected)
        {
            int[][] frames = new[]
            {
                new[]{ 0, 0},
                new[]{ 0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{0, 0},
                new[]{ roll1, roll2, roll3},
            };
            var sut = new Scoreboard(frames);

            var result = sut.CalculateFinalScore();

            result.Should().Be(expected);
        }

        [Fact]
        public void ScoreboardCalculatesScoreCorrectly()
        {
            int[][] frames = new[]
            {
                new[]{4, 3},
                new[]{7, 3},
                new[]{5, 2},
                new[]{8, 1},
                new[]{4, 6},
                new[]{2, 4},
                new[]{8, 0},
                new[]{8, 0},
                new[]{8, 2},
                new[]{10, 1, 7},
            };

            var sut = new Scoreboard(frames);

            var result = sut.CalculateFinalScore();

            result.Should().Be(110);
        }
    }
}
