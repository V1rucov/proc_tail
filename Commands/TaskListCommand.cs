using Microsoft.Win32.TaskScheduler;
using proc_tail.Viewers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public class TaskListCommand : AbstractCommand
    {
        public override Regex Command { get; set; } = new Regex("task list");
        public override void Execute(string command)
        {
            TaskViewer taskViewer = new TaskViewer();
            var tasks = taskViewer.GetManyObjects([]);
            foreach (var task in tasks) {
                foreach (var act in task.Definition.Actions) {
                    Console.WriteLine($"{act}");
                }
                
            }
        }
    }
}
