using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    public interface IDisplayable
    {
        public string[] GetStringRow();
        public string[] GetStringCol();
    }
}
