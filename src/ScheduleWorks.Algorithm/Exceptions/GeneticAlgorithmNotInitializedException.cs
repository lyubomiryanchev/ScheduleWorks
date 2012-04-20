using System;

namespace ScheduleWorks.Algorithm
{
    public class GeneticAlgorithmNotInitializedException : GeneticAlgorithmException
    {
        public GeneticAlgorithmNotInitializedException()
        {
        }
        public GeneticAlgorithmNotInitializedException(string message)
            : base(message)
        {

        }
        public GeneticAlgorithmNotInitializedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
