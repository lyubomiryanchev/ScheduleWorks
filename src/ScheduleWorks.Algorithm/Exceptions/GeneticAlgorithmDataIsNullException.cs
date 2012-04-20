using System;

namespace ScheduleWorks.Algorithm
{
    public class GeneticAlgorithmDataIsNullException : GeneticAlgorithmNotInitializedException
    {
        public GeneticAlgorithmDataIsNullException()
        {
        }
        public GeneticAlgorithmDataIsNullException(string message)
            : base(message)
        {

        }
        public GeneticAlgorithmDataIsNullException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
