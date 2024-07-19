using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Viewers
{
    public abstract class AbstractViewer
    {
        public abstract SimplifiedProcess Process { get; set; }
        public abstract SimplifiedProcess GetProcess(int ProcessId, string ProcessName = null);

    }
}
