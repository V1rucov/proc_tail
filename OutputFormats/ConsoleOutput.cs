using proc_tail.Types;
using Spectre.Console;

namespace proc_tail.OutputFormats
{
    public class ConsoleOutput : AbstractOutputFormat
    {
        public override void DisplayManyObjects(string message, IDisplayable[] displayables)
        {
            if (displayables == null || displayables.Length == 0)
            {
                AnsiConsole.WriteLine("Nothing to show, seems empty...");
                return;
            }
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
            if (displayable == null)
            {
                AnsiConsole.WriteLine("Nothing to show, seems empty...");
                return;
            }
            AnsiConsole.WriteLine(message);

            var table = new Grid();
            foreach (var col in displayable.GetStringCol()) {
                table.AddColumn();
            }

            table.AddRow(displayable.GetStringCol());
            table.AddRow(displayable.GetStringRow());

            AnsiConsole.Write(table);
        }
    }
}
