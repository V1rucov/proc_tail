using proc_tail.OutputFormats;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public class ScanCommand : AbstractCommand
    {
        public ScanCommand(AbstractOutputFormat outputFormat) : base(outputFormat) { }
        public override Regex Command { get; set; } = new Regex("start default scan");

        public override void Execute(string command)
        {
            AnsiConsole.WriteLine("[*] Coming soon...");
        }
    }
}
