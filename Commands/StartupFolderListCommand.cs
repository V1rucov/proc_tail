using proc_tail.OutputFormats;
using proc_tail.Types;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public class StartupFolderListCommand : AbstractCommand
    {
        public StartupFolderListCommand(AbstractOutputFormat outputFormat) : base(outputFormat) { }
        public override Regex Command { get; set; } = new Regex("startup list");
        record class file_(string path) : IDisplayable
        {
            public string[] GetStringCol() => ["File path"];

            public string[] GetStringRow() => [path];
        }

        public override void Execute(string command)
        {
            List<file_> files = new List<file_>();
            foreach (var item in Directory.GetFiles(RunKeys.MachineStartupFolder)) files.Add(new file_(item));
            foreach (var item in Directory.GetFiles(RunKeys.UserStartupFolder.Replace("[Username]", Environment.UserName))) files.Add(new file_(item));

            OutputFormat.DisplayManyObjects("[*] Files in Startup folders:", files.ToArray());
        }
    }
}
