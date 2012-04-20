using System;

namespace ScheduleWorks.Algorithm
{
    public class GeneticAlgorithmDifficultyPatternIsNullException : GeneticAlgorithmNotInitializedException
    {
        public GeneticAlgorithmDifficultyPatternIsNullException()
        {
        }
        public GeneticAlgorithmDifficultyPatternIsNullException(string message)
            : base(message)
        {

        }
        public GeneticAlgorithmDifficultyPatternIsNullException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
