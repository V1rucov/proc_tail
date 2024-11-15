using proc_tail.Types;
using proc_tail.Viewers;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace proc_tail.Commands
{
    public class AnalyzeRegistryCommand : AbstractCommand
    {
        public Regex Command { get; set; } = new Regex(@"reg list");

        public override void Execute(string command)
        {
            AnsiConsole.WriteLine("[*] Important registry keys:");

            RegistryViewer registryViewer = new RegistryViewer();
            Table table = new Table();
            table.AddColumn("key");
            table.AddColumn("value");

            var res = new List<string[]>();

            res.AddRange(registryViewer.GetManyObjects([MainRegistryKeys.CurrentUserRoot,MainRegistryKeys.RunPath]));
            res.AddRange(registryViewer.GetManyObjects([MainRegistryKeys.CurrentUserRoot, MainRegistryKeys.RunOncePath]));

            res.AddRange(registryViewer.GetManyObjects([MainRegistryKeys.MachineRoot, MainRegistryKeys.RunPath]));
            res.AddRange(registryViewer.GetManyObjects([MainRegistryKeys.MachineRoot, MainRegistryKeys.RunOncePath]));

            res.AddRange(registryViewer.GetManyObjects([MainRegistryKeys.CurrentUserRoot, MainRegistryKeys.LogonScript]));
            res.AddRange(registryViewer.GetManyObjects([MainRegistryKeys.CurrentUserRoot, MainRegistryKeys.WinlogonScript]));

            foreach (var cc in res) {
                if (cc[1]=="hidden") {
                    cc[1] = registryViewer.GetSingleObject(cc)[1];
                }
                if (cc[1].ToString() == "System.Byte[]") table.AddRow(cc[0], "bytes");
                else table.AddRow(cc[0], cc[1]);
            }
            AnsiConsole.Write(table);
            
            Console.WriteLine();
        }
    }
}
