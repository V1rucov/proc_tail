using proc_tail.Viewers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public abstract class AbstractCommand
    {
        public ApplicationContext Context { get; set; }
        public AbstractViewer Viewer { get; set; }
        public abstract void Execute();
    }
}
