using System.Management;

namespace proc_tail.Viewers
{
    public class WMIViewer : AbstractViewer
    { 
        public override SimplifiedProcess GetProcessInfo(int ProcessId, string ProcessName = null) 
        {
            if (ProcessId == -1) return null;
            var mos = new ManagementObjectSearcher($"SELECT * FROM Win32_Process WHERE ProcessId = {ProcessId}");
            var array = mos.Get().Cast<ManagementObject>().ToArray();
            if (array.Count() != 0) return array.First();
            else return null;
        }
    }
}
