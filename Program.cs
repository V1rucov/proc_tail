using System;
using System.Text.RegularExpressions;
using proc_tail.Commands;
using proc_tail.Viewers;
using Spectre.Console;

namespace proc_tail {
    public static class Program {
        static ICommand command;

        static DictionaryWithDefault<Regex, ICommand> Commands = new DictionaryWithDefault<Regex, ICommand>() {
            {new Regex(@"process reg (\d)+"), new AnalyzeRegistryCommand() },
            {new Regex(@"process tree (\d)+"), new TreeSnapshotCommand() },
            {new Regex(@"process list"), new ProcessListCommand() },
            {new Regex(@"easter egg"), new EasterEggCommand() }
        };

        static Panel Header = new Panel("[yellow]An process inspection tool\nAuthor - V1rucov \ngithub - https://github.com/V1rucov/proc_tail[/]");

        public static void Main() {
            Header.Header = new PanelHeader("proc_tail");
            AnsiConsole.Write(Header);

            while (true)
            {
                try
                {
                    string _m = AnsiConsole.Ask<string>($"{Environment.UserName}:> ");
                    command = Commands.FirstOrDefault(c => c.Key.Match(_m).Success).Value;
                    if (command != null) command.Execute(_m);
                    else AnsiConsole.WriteLine("\t wrong command");
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case System.InvalidOperationException or System.OverflowException:
                            AnsiConsole.Markup("[red]ERROR: wrong PID. Process not found.[/]");
                            break;
                        default:
                            AnsiConsole.Markup($"[red]ERROR: {ex.Message}[/]\n {ex.InnerException} \n\n {ex.StackTrace}");
                            break;
                    }
                    Console.WriteLine();
                }
                finally {
                    AnsiConsole.Write(new Rule());
                }
            }
        }
    }
}