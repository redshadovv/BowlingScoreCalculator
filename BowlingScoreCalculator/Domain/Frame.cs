using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreCalculator.Domain
{
    public class Frame
    {
        public int Number { get; }
        public List<int> Rolls { get; }

        public Frame(int number, IEnumerable<int> rolls)
        {
            var rollsList = rolls.ToList();

            // validate
            // TODO: disallow having second roll in frame 1-9 when first roll is a strike 
            switch (number)
            {
                case var num when num > 0 && num < 10:
                    if (rollsList.Count != 2 && rollsList.Count != 1)
                    {
                        throw new ArgumentException("Frame number 1-9 must have one or two rolls");
                    }
                    break;
                case 10:
                    if (rollsList.Count != 2 && rollsList.Count != 3)
                    {
                        throw new ArgumentException("Frame number 10 must have two or three rolls");
                    }
                    break;
                default:
                    throw new ArgumentException("Frame number must be between 1 and 10");
            }

            Number = number;
            Rolls = rollsList;
        }

        public int CalculateScore(int nextRoll, int nextNextRoll, bool isLastFrame = false)
        {
            return (DetermineScoreType(), isLastFrame) switch
            {
                (_, true) => Rolls.Sum(),
                (ScoreType.Strike, false) => 10 + nextRoll + nextNextRoll,
                (ScoreType.Spare, false) => 10 +nextRoll,
                (ScoreType.Normal, false) => Rolls[0] + Rolls[1],
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public ScoreType DetermineScoreType() =>
            Rolls[0] == 10
                ? ScoreType.Strike
                : Rolls[0] + Rolls[1] == 10
                    ? ScoreType.Spare
                    : ScoreType.Normal;
    }
}
