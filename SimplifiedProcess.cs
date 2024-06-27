using System.Management;

namespace proc_tail
{
    public class SimplifiedProcess
    {
        //public SimplifiedProcess? Parent { get; set; } Why???
        public SimplifiedProcess?[] Children { get; set; }
        public string Name { get; set; }
        public string ExecutablePath { get; set; }
        public string Pid { get; set; }

        public static explicit operator SimplifiedProcess(ManagementObject proc) {
            return new SimplifiedProcess() { 
                Name = proc["Name"].ToString(),
                ExecutablePath = proc["ExecutablePath"].ToString(),
                Pid = proc["ProcessId"].ToString()
            };
        }
    }
}
