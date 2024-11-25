using proc_tail.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.OutputFormats
{
    public abstract class AbstractOutputFormat
    {
        public abstract void DisplayManyObjects(string message, IDisplayable[] displayables);
        public abstract void DisplaySingleObject(string message, IDisplayable displayable);
    }
}
