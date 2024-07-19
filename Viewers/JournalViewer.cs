using System;
using System.Diagnostics;

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
