using proc_tail.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using WmiLight;

namespace proc_tail.Viewers
{
    public class WMISubViewer : AbstractViewer<SimplifiedWMISub>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">[0] - namespacepath, [1] - class</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override List<SimplifiedWMISub> GetManyObjects(string[] args)
        {
            using (WmiConnection con = new WmiConnection($"\\\\.\\{args[0]}")) {
                var list = con.CreateQuery($"SELECT * FROM {args[1]}").ToList();
                //ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

                List<SimplifiedWMISub> simplifiedWMISubs = new List<SimplifiedWMISub>();
                list.ForEach(s => { simplifiedWMISubs.Add(s); });
                return simplifiedWMISubs;
            }
        }

        public override SimplifiedWMISub GetSingleObject(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
