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

        public static implicit operator SimplifiedProcess(ManagementObject proc) {
            Console.WriteLine(proc["Name"]);
            SimplifiedProcess sp = new SimplifiedProcess()
            {
                Name = proc["Name"].ToString(),
                Pid = proc["ProcessId"].ToString()
            };
            if (proc["ExecutablePath"] != null) sp.ExecutablePath = proc["ExecutablePath"].ToString();
            return sp;

        }

    }
}
