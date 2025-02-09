using proc_tail.OutputFormats;
using proc_tail.Viewers;
using System.Text.RegularExpressions;

namespace proc_tail.Commands
{
    public class CheckHashCommand : AbstractCommand
    {
        public CheckHashCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }
        public override Regex Command { get; set; } = new Regex(@"check-hash");

        public override void Execute(string command)
        {
            var viewer = new ProcessViewer();
            var list = viewer.GetManyObjects([]);

            OutputFormat.DisplayManyObjects("[*] All processes:", list.ToArray());
        }
    }
}
