using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    public class MainRegistryKeys
    {
        public const string MachineUsersRoot = "HKEY_USERS";
        public const string CurrentUserRoot = "HKEY_CURRENT_USER";
        public const string MachineRoot = "HKEY_LOCAL_MACHINE";

        public const string RunPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public const string RunOncePath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce";

        public const string Winlogon = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon";

        public const string Enviroonment = "Environment";
        //public const string UserLogonScript = "Environment\\UserInitMprLogonScript";
    }
}
