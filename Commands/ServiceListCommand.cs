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
        public override Regex Command { get; set; } = new Regex("srv list");

        public override void Execute(string command)
        {
            AnsiConsole.WriteLine("[*] Services installed on PC:");

            ServiceViewer serviceViewer = new ServiceViewer();
            Table table = new Table();
            table.AddColumn("PID");
            table.AddColumn("Name");
            table.AddColumn("Path");

            var list = serviceViewer.GetManyObjects(new string[]{ });
            foreach (var item in list) {
                table.AddRow(item.ProcessId.ToString(), item.Name.ToString(), item.PathName.ToString());
            }
            AnsiConsole.Write(table);
        }
    }
}
