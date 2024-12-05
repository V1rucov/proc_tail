using proc_tail.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using WmiLight;

namespace proc_tail.Viewers
{
    public class ServiceViewer : AbstractViewer<SimplifiedService>
    {
        public override List<SimplifiedService> GetManyObjects(string[] args)
        {
            using (WmiConnection con = new WmiConnection()) {
                var list = con.CreateQuery($"SELECT * FROM Win32_Service").ToList();
                List<SimplifiedService> simplifiedServices = new List<SimplifiedService>();
                list.ForEach(o => simplifiedServices.Add(o));
                
                return simplifiedServices;
            }
        }

        public override SimplifiedService GetSingleObject(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
