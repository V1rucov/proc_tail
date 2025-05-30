﻿using proc_tail.OutputFormats;
using proc_tail.Viewers;
using System.Text.RegularExpressions;

namespace proc_tail.Commands
{
    public class ProcessListCommand : AbstractCommand
    {
        public ProcessListCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }
        public override Regex Command { get; set; } = new Regex(@"proc list");

        public override void Execute(string command)
        {
            var viewer = new ProcessViewer();
            var list = viewer.GetManyObjects([]);

            OutputFormat.DisplayManyObjects("[*] All processes:", list.ToArray());
        }
    }
}
