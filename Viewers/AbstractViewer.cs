using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proc_tail.Types;

namespace proc_tail.Viewers
{
    public abstract class AbstractViewer<A>
    {
        public abstract A GetSingleObject(string[] args);
        public abstract List<A> GetManyObjects(string[] args);
    }
}
