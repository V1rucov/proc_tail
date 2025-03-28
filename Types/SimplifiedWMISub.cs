﻿using System;
using System.Collections.Generic;
using System.Linq;
using WmiLight;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    public class SimplifiedWMISub : IDisplayable
    {
        public string CommandLineTemplate { get; set; }
        public string DesktopName { get; set; }
        public string ExecutablePath { get; set; }
        public string Name { get; set; }
        public string[] GetStringCol() => ["CommandLine", "Desktop name", "Name", "Executable path"];
        public string[] GetStringRow() => [CommandLineTemplate, DesktopName, Name, ExecutablePath];

        public static implicit operator SimplifiedWMISub(WmiObject subscription) {
            var ss = new SimplifiedWMISub();
            ss.CommandLineTemplate = subscription["CommandLineTemplate"]?.ToString() ?? "null";
            ss.DesktopName = subscription["DesktopName"]?.ToString() ?? "null";
            ss.ExecutablePath = subscription["ExecutablePath"]?.ToString() ?? "null";
            ss.Name = subscription["Name"]?.ToString() ?? "null";

            return ss;
        }
    }
}
