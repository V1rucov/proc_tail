using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    public class SimplifiedWMISub : IDisplayable
    {
        public string CommandLineTemplate { get; set; }
        public string DesktopName { get; set; }
        public string ExecutablePath { get; set; }
        public string Name { get; set; }
        public string[] GetStringCol() => ["CommandLine", "Desktop name", "Executable path", "Name"];
        public string[] GetStringRow() => [CommandLineTemplate, DesktopName, ExecutablePath, Name];

        public static implicit operator SimplifiedWMISub(ManagementObject subscription) {
            var ss = new SimplifiedWMISub();
            ss.CommandLineTemplate = subscription["CommandLineTemplate"]?.ToString() ?? "null";
            ss.DesktopName = subscription["DesktopName"]?.ToString() ?? "null";
            ss.ExecutablePath = subscription["ExecutablePath"]?.ToString() ?? "null";
            ss.Name = subscription["Name"]?.ToString() ?? "null";

            return ss;
        }
    }
}
