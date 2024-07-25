using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Viewers
{
    public abstract class AbstractViewer
    {
        public SimplifiedProcess Process { get; set; }
        public abstract SimplifiedProcess GetProcessInfo(int ProcessId, string ProcessName = null);

    }
}
