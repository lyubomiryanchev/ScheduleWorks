using System;

namespace ScheduleWorks.Algorithm
{
    public class GeneticAlgorithmPeriodsNegativeNumberException : GeneticAlgorithmNotInitializedException
    {
        public GeneticAlgorithmPeriodsNegativeNumberException()
        {
        }
        public GeneticAlgorithmPeriodsNegativeNumberException(string message)
            : base(message)
        {

        }
        public GeneticAlgorithmPeriodsNegativeNumberException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
