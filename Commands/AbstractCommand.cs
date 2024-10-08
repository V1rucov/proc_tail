using proc_tail.Viewers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace proc_tail.Commands
{
    public interface ICommand
    {
        public void Execute(string command);
        public Regex Command { get; set; }
    }
}
