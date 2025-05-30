﻿using proc_tail.OutputFormats;
using proc_tail.Types;
using proc_tail.Viewers;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace proc_tail.Commands
{
    public class AnalyzeRegistryCommand : AbstractCommand
    {
        public AnalyzeRegistryCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }
        public override Regex Command { get; set; } = new Regex(@"reg list");

        public override void Execute(string command)
        {
            AnsiConsole.WriteLine();

            RegistryViewer registryViewer = new RegistryViewer();

            List<SimplifiedRegKey> simplifiedRegKeys = new List<SimplifiedRegKey>();
            var res = new List<string[]>();

            res.AddRange(registryViewer.GetManyObjects([RunKeys.CurrentUserRoot, RunKeys.RunPath]));
            res.AddRange(registryViewer.GetManyObjects([RunKeys.CurrentUserRoot, RunKeys.RunOncePath]));

            res.AddRange(registryViewer.GetManyObjects([RunKeys.MachineRoot, RunKeys.RunPath]));
            res.AddRange(registryViewer.GetManyObjects([RunKeys.MachineRoot, RunKeys.RunOncePath]));

            res.AddRange(registryViewer.GetManyObjects([RunKeys.CurrentUserRoot, RunKeys.Enviroonment]));
            res.AddRange(registryViewer.GetManyObjects([RunKeys.CurrentUserRoot, RunKeys.Winlogon]));
            res.AddRange(registryViewer.GetManyObjects([RunKeys.MachineRoot, RunKeys.Winlogon]));

            res.AddRange(registryViewer.GetManyObjects([RunKeys.MachineRoot, RunKeys.Explorer]));
            res.AddRange(registryViewer.GetManyObjects([RunKeys.CurrentUserRoot, RunKeys.Explorer]));
            
            //res.AddRange(registryViewer.GetManyObjects([RunKeys.MachineRoot, RunKeys.SessionManager]));
            //res.AddRange(registryViewer.GetManyObjects([RunKeys.MachineRoot, RunKeys.TimeProvider]));

            foreach (var cc in res)
            {
                if (cc[1] == "hidden")
                {
                    cc[1] = registryViewer.GetSingleObject(cc)[1];
                }
                if (cc[1].ToString() == "System.Byte[]") simplifiedRegKeys.Add(new SimplifiedRegKey() { Key = cc[0], Value = "bytes" });
                else simplifiedRegKeys.Add(cc);
            }

            OutputFormat.DisplayManyObjects("[*] Important registry keys:", simplifiedRegKeys.ToArray());
        }
    }
}
