using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using WmiLight;

namespace proc_tail.Types
{
    public class SimplifiedService : IDisplayable
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int ProcessId { get; set; }
        public string ServiceType { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public string InstallDate { get; set; }
        public string PathName { get; set; }

        public string[] GetStringCol() => ["PID","Name","Path"];

        public string[] GetStringRow() => [ProcessId.ToString(), Name, PathName];

        public static implicit operator SimplifiedService(WmiObject srv)
        {
            SimplifiedService ss = new SimplifiedService();
            ss.Name = srv["Name"]?.ToString() ?? "-";
            ss.DisplayName = srv["DisplayName"]?.ToString() ?? "-";
            ss.ProcessId = Int32.Parse(srv["ProcessId"]?.ToString() ?? "0");
            ss.ServiceType = srv["ServiceType"]?.ToString() ?? "-";
            ss.State = srv["State"]?.ToString() ?? "-";
            ss.Status = srv["Status"]?.ToString() ?? "-";
            ss.PathName = srv["PathName"]?.ToString() ?? "-";
            ss.InstallDate = srv["InstallDate"]?.ToString() ?? "2000";

            return ss;
        }
    }
}
