using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    [Flags]
    public enum RelativeSubjectDifficulty
    {
		None = 0x0,
        Low = 0x1,
        Normal = 0x2,
        High = 0x4
    }
}
