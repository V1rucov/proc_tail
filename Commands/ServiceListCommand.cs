using proc_tail.OutputFormats;
using proc_tail.Viewers;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public class ServiceListCommand : AbstractCommand
    {
        public ServiceListCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }
        public override Regex Command { get; set; } = new Regex("srv list");

        public override void Execute(string command)
        {
            ServiceViewer serviceViewer = new ServiceViewer();
            var list = serviceViewer.GetManyObjects(new string[]{ });

            OutputFormat.DisplayManyObjects("[*] Services installed on PC:", list.ToArray());
        }
    }
}
