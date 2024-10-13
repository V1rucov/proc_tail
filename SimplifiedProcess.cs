using System.Management;

namespace proc_tail
{
    public class SimplifiedProcess
    {
        public SimplifiedProcess?[] Children { get; set; }
        public SimplifiedProcess Parent { get; set; }
        public string Name { get; set; }
        public string ExecutablePath { get; set; }
        public int Pid { get; set; }

        public static implicit operator SimplifiedProcess(ManagementObject proc)
        {
            //TODO: GetOwner
            SimplifiedProcess sp = new SimplifiedProcess();

            sp.Name = proc["Name"].ToString();
            sp.Pid = int.Parse(proc["ProcessId"].ToString());
            if (proc["ExecutablePath"] != null) sp.ExecutablePath = proc["ExecutablePath"].ToString();

            sp.Parent = new SimplifiedProcess();
            sp.Parent.Pid = int.Parse(proc["ParentProcessId"].ToString() ?? "-1");
            return sp;
        }
    }
}
