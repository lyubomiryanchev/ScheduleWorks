using System;

namespace ScheduleWorks.Algorithm
{
    public class GeneticAlgorithmException : Exception
    {
        public GeneticAlgorithmException()
            : base()
        {

        }
        public GeneticAlgorithmException(string message)
            : base(message)
        {

        }
        public GeneticAlgorithmException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
