using proc_tail.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

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
            ManagementScope scope = new ManagementScope($"\\\\.\\{args[0]}");
            scope.Connect();

            ObjectQuery query = new ObjectQuery($"SELECT * FROM {args[1]}");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);

            var array = searcher.Get().Cast<ManagementObject>().ToList();
            List<SimplifiedWMISub> simplifiedWMISubs = new List<SimplifiedWMISub>();
            array.ForEach(s => { simplifiedWMISubs.Add(s); });
            return simplifiedWMISubs;
        }

        public override SimplifiedWMISub GetSingleObject(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
