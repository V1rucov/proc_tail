using proc_tail.OutputFormats;
using proc_tail.Types;
using proc_tail.Viewers;
using Spectre.Console;
using System.Text.RegularExpressions;
using System.Diagnostics;
//using Microsoft.ConfigurationManagement.Messaging;

namespace proc_tail.Commands
{
    public class BitsJobsListCommand : AbstractCommand
    {
        public BitsJobsListCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }
        public override Regex Command { get; set; } = new Regex(@"bits list");

        public override void Execute(string command)
        {
            try
    {
        System.Diagnostics.Process bitsadmin_process = new System.Diagnostics.Process();
        bitsadmin_process.StartInfo = new System.Diagnostics.ProcessStartInfo("bitsadmin", "list");
        bitsadmin_process.Start();
        bitsadmin_process.WaitForExit();
        bitsadmin_process = null;
    }
    catch { }
        }
    }
}
