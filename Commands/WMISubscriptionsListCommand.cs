using proc_tail.OutputFormats;
using proc_tail.Viewers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public class WMISubscriptionsListCommand : AbstractCommand
    {
        public WMISubscriptionsListCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }

        public override Regex Command { get; set; } = new Regex("wmi sub list");

        public override void Execute(string command)
        {
            WMISubViewer wMISubViewer = new WMISubViewer();
            var list = wMISubViewer.GetManyObjects(new string[] { "root\\subscription", "CommandLineEventConsumer" });

            OutputFormat.DisplayManyObjects("[*] WMI Subscriptions on PC:", list.ToArray());
        }
    }
}
