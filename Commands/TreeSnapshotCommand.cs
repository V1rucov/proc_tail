using proc_tail.Types;
using proc_tail.Viewers;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    internal class TreeSnapshotCommand : ICommand
    {
        public Regex Command { get; set; } = new Regex(@"process tree (\d+)");

        public void Execute(string command) {
            int PID = Int32.Parse(Command.Match(command).Groups[1].Value);
            var Viewer = new ProcessViewer();
            string[] arg = { PID.ToString() };
            SimplifiedProcess proc = Viewer.GetSingleObject(arg);
            if (proc == null) throw new NullReferenceException("process not found");
            AnsiConsole.Markup($"\tProcess: {proc.Name}\n");
            GetParents(proc, Viewer);
            string path = AppDomain.CurrentDomain.BaseDirectory + $"{proc.Name}-{proc.Pid}.json";
            AnsiConsole.Markup($"\tJson file (process tree) created at {path}\n");
            using (StreamWriter sw = new StreamWriter(path)) {
                sw.Write(JsonSerializer.Serialize(proc));
            }
        }

        void GetParents(SimplifiedProcess proc, ProcessViewer Viewer) {
            if (proc == null || proc.Parent.Pid == -1 || proc.Pid == 4) return;
            if (proc.ExecutablePath == null) return;
            if (Regex.Match(proc.ExecutablePath, @"System32\\wininit\.exe").Success) return;

            string[] arg = { proc.Parent.Pid.ToString()};
            proc.Parent = (SimplifiedProcess)Viewer.GetSingleObject(arg);
            GetParents(proc.Parent, Viewer);
        }
    }
}
