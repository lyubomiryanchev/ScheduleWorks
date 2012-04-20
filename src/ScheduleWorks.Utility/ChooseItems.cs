using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScheduleWorks.Utility
{
    static public class ChooseItems
    {
        public enum Mode
        {
            MultipleItems,
            SingleItem
        }
    }

    public class ChooseItemsParameters
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public object Tag { get; set; }

        public ChooseItemsParameters() { }

        public ChooseItemsParameters(string name, string shortname, object tag)
        {
            Name = name;
            ShortName = shortname;
            Tag = tag;
        }
    }
}
