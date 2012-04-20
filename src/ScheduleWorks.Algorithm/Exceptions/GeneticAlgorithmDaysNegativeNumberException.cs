using System;

namespace ScheduleWorks.Algorithm
{
    public class GeneticAlgorithmDaysNegativeNumberException : GeneticAlgorithmNotInitializedException
    {
        public GeneticAlgorithmDaysNegativeNumberException()
        {
        }
        public GeneticAlgorithmDaysNegativeNumberException(string message)
            : base(message)
        {

        }
        public GeneticAlgorithmDaysNegativeNumberException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
