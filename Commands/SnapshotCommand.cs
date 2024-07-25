using proc_tail.Viewers;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    internal class SnapshotCommand : AbstractCommand
    {
        public SnapshotCommand(AbstractViewer _Viewer, ApplicationContext _Context) {
            Viewer = _Viewer;
            Context = _Context;
        }

        public override void Execute() {
            var proc = Viewer.GetProcessInfo(Context.ProcessId.Value, Context?.ProcessName);
            if (proc == null) throw new NullReferenceException("process not found");
            AnsiConsole.Markup($"\tProcess: {proc.Name}\n");
            GetParents(proc);
            string path = AppDomain.CurrentDomain.BaseDirectory + $"{proc.Name}-{proc.Pid}.json";
            AnsiConsole.Markup($"\tJson file (process tree) created at {path}\n");
            AnsiConsole.Write(new Rule());
            using (StreamWriter sw = new StreamWriter(path)) {
                sw.Write(JsonSerializer.Serialize(proc));
            }
        }

        void GetParents(SimplifiedProcess proc) {
            if (proc == null || proc.Parent.Pid == -1 || proc.Pid == 4) return;
            proc.Parent = Viewer.GetProcessInfo(proc.Parent.Pid);
            GetParents(proc.Parent);
        }
    }
}
