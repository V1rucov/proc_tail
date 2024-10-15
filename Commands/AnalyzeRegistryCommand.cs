using Microsoft.Win32;
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
    public class AnalyzeRegistryCommand : ICommand
    {
        const string MachineUsersRoot = "HKEY_USERS";
        const string CurrentUserRoot = "HKEY_CURRENT_USER";
        const string MachineRoot = "HKEY_LOCAL_MACHINE";

        const string RunPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        const string RunOncePath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce";

        public Regex Command { get; set; } = new Regex(@"reg check");

        public void Execute(string command)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RunPath);
            AnsiConsole.WriteLine("[*] registry machine run path:");
            key.GetValueNames()?.ToList().ForEach(cc => Console.WriteLine($"\t{cc}"));
            Console.WriteLine();

            key = Registry.LocalMachine.OpenSubKey(RunOncePath);
            AnsiConsole.WriteLine("[*] registry machine run once path:");
            key.GetValueNames()?.ToList().ForEach(cc => Console.WriteLine($"\t{cc}"));
            Console.WriteLine();

            key = Registry.CurrentUser.OpenSubKey(RunPath);
            AnsiConsole.WriteLine("[*] registry current user run path:");
            key.GetValueNames()?.ToList().ForEach(cc => Console.WriteLine($"\t{cc}"));
            Console.WriteLine();

            key = Registry.CurrentUser.OpenSubKey(RunOncePath);
            AnsiConsole.WriteLine("[*] registry current user run once path:");
            key.GetValueNames()?.ToList().ForEach(cc => Console.WriteLine($"\t{cc}"));
            Console.WriteLine();
        }
    }
}
