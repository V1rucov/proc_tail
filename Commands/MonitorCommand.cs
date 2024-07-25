using proc_tail.Viewers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public class MonitorCommand : AbstractCommand
    {
        public MonitorCommand(AbstractViewer _Viewer, ApplicationContext _Context)
        {
            Viewer = _Viewer;
            Context = _Context;
        }  

        public override void Execute()
        {
            var proc = Viewer.GetProcessInfo(Context.ProcessId.Value, Context.ProcessName);
            Console.WriteLine($"Process: {proc.Name}");
            Console.WriteLine();

            //TODO: GetParents

            
        }
    }
}
