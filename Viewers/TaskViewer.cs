using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Viewers
{
    public class TaskViewer : AbstractViewer<Microsoft.Win32.TaskScheduler.Task>
    {
        public override List<Microsoft.Win32.TaskScheduler.Task> GetManyObjects(string[] args) => TaskService.Instance.AllTasks.ToList();//EnumFolderTasks(TaskService.Instance.RootFolder);

        public override Microsoft.Win32.TaskScheduler.Task GetSingleObject(string[] args)
        {
            throw new NotImplementedException();
        }

        List<Microsoft.Win32.TaskScheduler.Task> EnumFolderTasks(TaskFolder fld)
        {
            var tasks = new List<Microsoft.Win32.TaskScheduler.Task>();
            foreach (var task in fld.Tasks)
                tasks.Add(task);
            foreach (TaskFolder sfld in fld.SubFolders)
                EnumFolderTasks(sfld);
            return tasks;
        }
    }
}
