using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    [Serializable]
    public class AlgorithmParameters
    {
        public RelativeSubjectDifficulty[] FourHoursPerDay = new RelativeSubjectDifficulty[4];
        public RelativeSubjectDifficulty[] FiveHoursPerDay = new RelativeSubjectDifficulty[5];
        public RelativeSubjectDifficulty[] SixHoursPerDay = new RelativeSubjectDifficulty[6];
        public RelativeSubjectDifficulty[] SevenHoursPerDay = new RelativeSubjectDifficulty[7];
    }
}
