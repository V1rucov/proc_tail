using proc_tail.Types;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proc_tail.OutputFormats
{
    public class ConsoleOutput : AbstractOutputFormat
    {
        public override void DisplayManyObjects(string message, IDisplayable[] displayables)
        {
            AnsiConsole.WriteLine(message);

            var table = new Grid();
            foreach (var col in displayables[0].GetStringCol()) {
                table.AddColumn();
            }
            table.AddRow(displayables[0].GetStringCol());
            foreach (var cc in displayables) table.AddRow(cc.GetStringRow());
            AnsiConsole.Write(table);
        }

        public override void DisplaySingleObject(string message, IDisplayable displayable)
        {
            throw new NotImplementedException();
        }
    }
}
