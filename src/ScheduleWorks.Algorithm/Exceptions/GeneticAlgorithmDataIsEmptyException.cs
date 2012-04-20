using System;

namespace ScheduleWorks.Algorithm
{
    public class GeneticAlgorithmDataIsEmptyException : GeneticAlgorithmNotInitializedException
    {
        public GeneticAlgorithmDataIsEmptyException()
        {
        }
        public GeneticAlgorithmDataIsEmptyException(string message)
            : base(message)
        {

        }
        public GeneticAlgorithmDataIsEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
