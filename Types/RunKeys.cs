using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    public class RunKeys
    {
        // https://attack.mitre.org/techniques/T1547/001/

        public const string CurrentUserRoot = "HKEY_CURRENT_USER";
        public const string MachineRoot = "HKEY_LOCAL_MACHINE";

        public const string RunPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        public const string RunOncePath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        public const string RunOnceExPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnceEx";

        public const string Winlogon = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon";

        public const string RunServicesOnce = "Software\\Microsoft\\Windows\\CurrentVersion\\RunServicesOnce";
        public const string RunServices = "Software\\Microsoft\\Windows\\CurrentVersion\\RunServices";

        public const string ExplorerRun = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\Run";
        public const string Explorer = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer"; //User Shell Folders | Shell Folders

        public const string Enviroonment = "Environment";

        public const string SessionManager = "System\\CurrentControlSet\\Control\\Session Manager";

        public const string TimeProvider = "System\\CurrentControlSet\\Services\\W32Time\\TimeProviders\\NtpClient";

        //

        public const string UserStartupFolder = "C:\\Users\\[Username]\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup";
        public const string MachineStartupFolder = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\StartUp";
    }
}
