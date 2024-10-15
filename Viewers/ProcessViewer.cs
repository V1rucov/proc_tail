using System.Management;
using proc_tail.Types;

namespace proc_tail.Viewers
{
    public class ProcessViewer : IViewer<int,SimplifiedProcess>
    {
        public SimplifiedProcess GetInfo(int ProcessId) 
        {
            if (ProcessId == -1) return null;
            var mos = new ManagementObjectSearcher($"SELECT * FROM Win32_Process WHERE ProcessId = {ProcessId}");
            var array = mos.Get().Cast<ManagementObject>().ToArray();
            if (array.Count() != 0) return array.First();
            else return null;
        }
    }
}
