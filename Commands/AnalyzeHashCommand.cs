using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proc_tail.Viewers;

namespace proc_tail.Commands
{
    public class AnalyzeHashCommand : AbstractCommand
    {
        public AnalyzeHashCommand(AbstractViewer _Viewer, ApplicationContext _Context)
        {
            Viewer = _Viewer;
            Context = _Context;
        }
        public override void Execute()
        {
            
        }
    }
}
