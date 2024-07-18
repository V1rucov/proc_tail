using System.Management;

namespace proc_tail
{
    public class SimplifiedProcess
    {
        public SimplifiedProcess?[] Children { get; set; }
        public string Name { get; set; }
        public string ExecutablePath { get; set; }
        public int? Pid { get; set; }
        public int? ParentPid { get; set; }

        public static implicit operator SimplifiedProcess(ManagementObject proc) {
            Console.WriteLine(proc["Name"]);
            SimplifiedProcess sp = new SimplifiedProcess()
            {
                Name = proc["Name"].ToString(),
                Pid = Int32.Parse(proc["ProcessId"].ToString() ?? "-1"),
                ExecutablePath = proc["ExecutablePath"].ToString() ?? "None",
                ParentPid = Int32.Parse(proc["ParentProcessId"].ToString() ?? "-1")
            };
            return sp;
        }
    }
}
