using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proc_tail.Types;

namespace proc_tail.Viewers
{
    public interface IViewer<T,A>
    {
        public abstract A GetInfo(T Arg1);
    }
}
