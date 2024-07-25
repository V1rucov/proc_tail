using proc_tail.Viewers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public class AnalyzeRegistryCommand : AbstractCommand
    {
        public AnalyzeRegistryCommand(AbstractViewer _Viewer, ApplicationContext _Context)
        {
            Viewer = _Viewer;
            Context = _Context;
        }
        public override void Execute()
        {
            //string machineUsersRoot = "HKEY_USERS";
            string currentUserRoot = "HKEY_CURRENT_USER";
            string machineRoot = "HKEY_LOCAL_MACHINE";

            string runPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            string runOncePath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        }

    }
}
