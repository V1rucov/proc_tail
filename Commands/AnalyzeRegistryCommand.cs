using Microsoft.Win32;
using proc_tail.Types;
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
        public Regex Command { get; set; } = new Regex(@"reg list");

        public void Execute(string command)
        {
            AnsiConsole.WriteLine("[*] Important registry keys:");

            RegistryViewer registryViewer = new RegistryViewer();
            Table table = new Table();
            table.AddColumn("key");
            table.AddColumn("value");

            var res = registryViewer.GetManyObjects(new string[] {MainRegistryKeys.CurrentUserRoot,MainRegistryKeys.RunPath });
            res.AddRange(registryViewer.GetManyObjects(new string[] { MainRegistryKeys.CurrentUserRoot, MainRegistryKeys.RunOncePath }));

            res.AddRange(registryViewer.GetManyObjects(new string[] { MainRegistryKeys.MachineRoot, MainRegistryKeys.RunPath }));
            res.AddRange(registryViewer.GetManyObjects(new string[] { MainRegistryKeys.MachineRoot, MainRegistryKeys.RunOncePath }));

            res.AddRange(registryViewer.GetManyObjects(new string[] { MainRegistryKeys.CurrentUserRoot, MainRegistryKeys.LogonScript }));
            //res.AddRange(registryViewer.GetManyObjects(new string[] { MainRegistryKeys.CurrentUserRoot, MainRegistryKeys.WinlogonScript }));

            foreach (var cc in res) {
                table.AddRow(cc[0].ToString(), cc[1].ToString());
                //Console.WriteLine(cc[0]+" " + cc[1]);
            }
            AnsiConsole.Write(table);
            
            Console.WriteLine();
        }
    }
}
