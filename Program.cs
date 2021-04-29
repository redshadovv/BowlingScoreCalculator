using System;
using BowlingScoreCalculator.Domain;

namespace BowlingScoreCalculator
{
    class Program
    {
        static void Main()
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

            Scoreboard scoreboard = new Scoreboard(frames);
            var score = scoreboard.CalculateFinalScore();

            Console.WriteLine($"Your final score is: {score}");
        }
    }
}
