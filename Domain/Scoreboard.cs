using System;
using System.Collections.Generic;

namespace BowlingScoreCalculator.Domain
{
    public class Scoreboard
    {
        private readonly SortedList<int, Frame> _frames;

        public Scoreboard(int[][] frames)
        {
            if (frames.Length != 10)
            {
                throw new ArgumentException("Scoreboard must have exactly 10 frames");
            }

            _frames = new SortedList<int, Frame>();
            for (var i = 1; i <= frames.Length; i++)
            {
                int[] rolls = frames[i-1];
                _frames[i] = new Frame(i, rolls);
            }
        }

        public int CalculateFinalScore()
        {
            int score = 0;

            for (int i = 1; i <= 10; i++)
            {
                var nextRolls = GetNextTwoRolls(i);
                score += _frames[i].CalculateScore(nextRolls.Item1, nextRolls.Item2, i == 10);
            }

            return score;
        }

        private (int, int) GetNextTwoRolls(int frameNumber)
        {
            if (frameNumber == 10)
            {
                return (_frames[10].Rolls[1],
                    _frames[10].Rolls.Count > 2 ? _frames[10].Rolls[2] : 0);
            }

            var nextFrame = _frames[frameNumber + 1];
            int nextRoll = nextFrame.Rolls[0];
            int nextNextRoll = nextFrame.Number == 10
                ? nextFrame.Rolls[1]
                : nextFrame.DetermineScoreType() == ScoreType.Strike
                    ? _frames[frameNumber + 2].Rolls[0]
                    : nextFrame.Rolls[1];

            return (nextRoll, nextNextRoll);
        }
    }
}
