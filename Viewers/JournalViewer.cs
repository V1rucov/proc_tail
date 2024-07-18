using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Viewers
{
    public class JournalViewer : AbstractViewer
    {
        public override SimplifiedProcess Process { get; set; }
        public override SimplifiedProcess GetProcess(int ProcessId, string ProcessName = null)
        {
            return null;
        }
    }
}
