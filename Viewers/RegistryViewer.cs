using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Viewers
{
    public class RegistryViewer : AbstractViewer
    {
        public override SimplifiedProcess GetProcessInfo(int ProcessId, string ProcessName = null)
        {
            return null;
        }
    }
}
