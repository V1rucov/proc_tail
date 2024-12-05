using proc_tail.OutputFormats;
using proc_tail.Types;
using proc_tail.Viewers;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public class ProcessListCommand : AbstractCommand
    {
        public ProcessListCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }
        public override Regex Command { get; set; } = new Regex(@"process list");

        public override void Execute(string command)
        {
            var viewer = new ProcessViewer();
            var list = viewer.GetManyObjects([]);

            OutputFormat.DisplayManyObjects("[*] All processes:", list.ToArray());
        }
    }
}
