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
    public abstract class AbstractCommand
    {
        public abstract void Execute(string command);
        public AbstractOutputFormat OutputFormat { get; set; }
        public Regex Command { get; set; }
    }
}
