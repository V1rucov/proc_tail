using proc_tail.Viewers;
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
        public Regex Command { get; set; } = new Regex(@"process reg (\d+)");

        public void Execute(string command)
        {
            string machineUsersRoot = "HKEY_USERS";
            string currentUserRoot = "HKEY_CURRENT_USER";
            string machineRoot = "HKEY_LOCAL_MACHINE";

            string runPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            string runOncePath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        }

    }
}
