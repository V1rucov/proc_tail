using System.Management;

namespace proc_tail.Viewers
{
    public class Win32Viewer : AbstractViewer
    {
        public override SimplifiedProcess Process { get; set; }
        public override SimplifiedProcess GetProcess(int ProcessId, string ProcessName = null) 
        {
            var mos = new ManagementObjectSearcher($"SELECT * FROM Win32_Process WHERE ProcessId = {ProcessId}");
            return mos.Get().Cast<ManagementObject>().ToArray().First();
        }
    }
}
