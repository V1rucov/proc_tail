using proc_tail.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Viewers
{
    public class ServiceViewer : IViewer<SimplifiedService>
    {
        public List<SimplifiedService> GetManyObjects(string[] args)
        {
            var mos = new ManagementObjectSearcher($"SELECT * FROM Win32_Service");
            
            var array = mos.Get().Cast<ManagementObject>().ToArray();
            var list = new List<SimplifiedService>();
            foreach (var item in array)
            {
                list.Add((SimplifiedService)item);
            }
            return list;
        }

        public SimplifiedService GetSingleObject(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
