using System.Diagnostics;
using System.Management;
using proc_tail.Types;
using WmiLight;

namespace proc_tail.Viewers
{
    public class ProcessViewer : AbstractViewer<SimplifiedProcess>
    {
        public override SimplifiedProcess GetSingleObject(string[] args) 
        {
            int ProcessId = Int32.Parse(args[0]);
            if (ProcessId == -1) return null;
            using (WmiConnection con = new WmiConnection()) {
                var list = con.CreateQuery($"SELECT * FROM Win32_Process WHERE ProcessId = {ProcessId}").ToList();
                if (list.Count() != 0) return list.First();
                else return null;
            }
        }

        public override List<SimplifiedProcess> GetManyObjects(string[] args) {
            using (WmiConnection con = new WmiConnection())
            {
                var list = con.CreateQuery($"SELECT * FROM Win32_Process").ToList();
                List<SimplifiedProcess> simplifiedProcesses = new List<SimplifiedProcess>();
                list.ForEach(o => simplifiedProcesses.Add(o));
                return simplifiedProcesses;
            }
        }
    }
}
