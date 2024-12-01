using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    public class SimplifiedWMISub : IDisplayable
    {
        public string[] GetStringCol()
        {
            throw new NotImplementedException();
        }

        public string[] GetStringRow()
        {
            throw new NotImplementedException();
        }

        public static implicit operator SimplifiedWMISub(ManagementObject subscription) {
            //TODO: type casting
            foreach (var sub in subscription.Properties) { 
                Console.WriteLine($"{sub.Name} - {sub.Value}");
            }
            return new SimplifiedWMISub();
        }
    }
}
