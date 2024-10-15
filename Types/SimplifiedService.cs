using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    internal class SimplifiedService
    {
        string Name { get; set; }
        string DisplayName { get; set; }
        string Description { get; set; }
        int ProcessId { get; set; }
        string ServiceType { get; set; }
        string State { get; set; }
        string Status { get; set; }
        DateTime InstallDate { get; set; }

        public static implicit operator SimplifiedService(ManagementObject srv)
        {
            SimplifiedService ss = new SimplifiedService();
            return ss;
        }
    }
}
