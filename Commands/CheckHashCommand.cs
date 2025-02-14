using Newtonsoft.Json;
using proc_tail.OutputFormats;
using proc_tail.TI;
using proc_tail.Viewers;
using System.Text.RegularExpressions;

namespace proc_tail.Commands
{
    public class CheckHashCommand : AbstractCommand
    {
        public CheckHashCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }
        public override Regex Command { get; set; } = new Regex(@"check-hash ((?<first>\-n (\d+))|(?<second>[a-zA-Z0-9]+))+");

        public override void Execute(string command)
        {
            var vt = new VirusTotalApi();
            if(Command.Match(command).Groups["first"].Success){
                var hash = Command.Match(command).Groups["first"].Value;
                Console.WriteLine("1");
            }
            else if(Command.Match(command).Groups["second"].Success) {
                var hash = Command.Match(command).Groups["second"].Value;
                var response = vt.CheckHash(hash);
                Console.WriteLine(response.Data.Attributes.PopularThreatClassification.PopularThreatName[0].Value);
            }
        }
    }
}
