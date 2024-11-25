using proc_tail.OutputFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    internal class EasterEggCommand : AbstractCommand
    {
        public EasterEggCommand(AbstractOutputFormat OutputFormat) : base(OutputFormat) { }
        public override Regex Command { get; set; } = new Regex(@"easter egg");

        public override void Execute(string command)
        {
            string woman = "Pretty woman!\r\n                               _.._\r\n                             .'    '.\r\n                            (____/`\\ \\\r\n                           (  |' ' )  )\r\n                           )  _\\= _/  (\r\n                 __..---.(`_.'  ` \\    )\r\n                `;-\"\"-._(_( .      `; (\r\n                /       `-`'--'     ; )\r\n               /    /  .    ( .  ,| |(\r\n_.-`'---...__,'    /-,..___.-'--'_| |_)\r\n'-'``'-.._       ,'  |   / .........'\r\n          ``;--\"`;   |   `-`\r\n             `'..__.'";
            Console.WriteLine(woman);
        }
    }
}
