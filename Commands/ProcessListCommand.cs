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
    internal class ProcessListCommand : AbstractCommand
    {
        public override Regex Command { get; set; } = new Regex(@"process list");

        public override void Execute(string command)
        {
            var mos = new ManagementObjectSearcher($"SELECT * FROM Win32_Process");
            var array = mos.Get().Cast<ManagementObject>().ToArray();

            var table = new Table();
            table.AddColumn("PID");
            table.AddColumn("Name");
            table.AddColumn("Executable");

            AnsiConsole.WriteLine("[*] All processes:");
            foreach (var cc in array) table.AddRow(cc["ProcessId"].ToString(), cc["Name"].ToString(), cc["ExecutablePath"]?.ToString() ?? "null");
            AnsiConsole.Write(table);
        }
    }
}
