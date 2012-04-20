using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ScheduleWorks.Utility
{
    public static class RandomColor
    {
        public static Random rand = new Random();
        public static Color GetRandomColor()
        {
            rand.Next();
            return Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }
    }
}
