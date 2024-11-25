using System.Management;

namespace proc_tail.Types
{
    public class SimplifiedProcess : IDisplayable
    {
        public string Owner { get; set; }
        public SimplifiedProcess?[] Children { get; set; }
        public SimplifiedProcess Parent { get; set; }
        public string Name { get; set; }
        public string ExecutablePath { get; set; }
        public int Pid { get; set; }

        public string[] GetStringCol() => ["PID","Name", "Executable" ];

        public string[] GetStringRow() => [Pid.ToString(), Name, ExecutablePath];

        public static implicit operator SimplifiedProcess(ManagementObject proc)
        {
            //TODO: GetOwner
            SimplifiedProcess sp = new SimplifiedProcess();

            sp.Name = proc["Name"].ToString();
            sp.Pid = int.Parse(proc["ProcessId"].ToString());
            if (proc["ExecutablePath"] != null) sp.ExecutablePath = proc["ExecutablePath"].ToString();
            else sp.ExecutablePath = "null";

            sp.Parent = new SimplifiedProcess();
            sp.Parent.Pid = int.Parse(proc["ParentProcessId"].ToString() ?? "-1");
            return sp;
        }
    }
}
