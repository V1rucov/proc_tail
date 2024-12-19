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
    public class ScanCommand : AbstractCommand
    {
        public ScanCommand(AbstractOutputFormat outputFormat) : base(outputFormat) { }
        public override Regex Command { get; set; } = new Regex("start hunt");

        public override async void Execute(string command)
        {
            AnsiConsole.Markup("[maroon]Let the Hunt begin![/]\n");

            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    // Define tasks
                    var task1 = ctx.AddTask("[maroon]Hunting threats...[/]");

                    while (!ctx.IsFinished)
                    {
                        Thread.Sleep(100);
                        task1.Increment(1);
                    }
                });

            //Thread.Sleep(10000);
            //throw new NotImplementedException();
        }
    }
}
