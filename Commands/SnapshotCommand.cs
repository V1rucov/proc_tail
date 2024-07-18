using proc_tail.Viewers;
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

        AbstractViewer Viewer { get; set; }
        public override ApplicationContext Context { get; set; }

        public override void Execute() {
            var proc = Viewer.GetProcess(Context.ProcessId, Context.ProcessName);
            Console.WriteLine($"Process: {proc.Name}");
            Console.WriteLine();

            //TODO: GetParents

            string path = AppDomain.CurrentDomain.BaseDirectory + $"{proc.Name}-{proc.Pid}.json";

            Console.WriteLine($"Json file created at {path}");
            Console.WriteLine("===========================================================");

            using (StreamWriter sw = new StreamWriter(path)) {
                sw.Write(JsonSerializer.Serialize(proc));
            }
        }
    }
}
