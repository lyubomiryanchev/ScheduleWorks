using System;

namespace ScheduleWorks.Algorithm
{
    public class GeneticAlgorithmInitializationNotStartedException : GeneticAlgorithmException
    {
        public GeneticAlgorithmInitializationNotStartedException() { }
        public GeneticAlgorithmInitializationNotStartedException(string message)
            : base(message)
        {

        }
        public GeneticAlgorithmInitializationNotStartedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
