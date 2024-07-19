using System.Management;

namespace proc_tail.Viewers
{
    public class Win32Viewer : AbstractViewer
    {
        public override SimplifiedProcess Process { get; set; }
        public override SimplifiedProcess GetProcess(int ProcessId, string ProcessName = null) 
        {
            if (ProcessId == -1) return null;
            var mos = new ManagementObjectSearcher($"SELECT * FROM Win32_Process WHERE ProcessId = {ProcessId}");
            var array = mos.Get().Cast<ManagementObject>().ToArray();
            if (array.Count() != 0) return array.First();
            else return null;
        }
    }
}
