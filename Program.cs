#define DEV

using System;
using System.Text.RegularExpressions;
using proc_tail.Commands;
using proc_tail.Viewers;
using Spectre.Console;

namespace proc_tail {
    public static class Program {
        static ICommand command;

        static List<ICommand>? Commands = new List<ICommand>() {
            new AnalyzeRegistryCommand(),
            new EasterEggCommand(),
            new ProcessListCommand(),
            new TreeSnapshotCommand()
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
                    command = Commands.FirstOrDefault(c => c.Command.Match(_m).Success);
                    if (command != null) command.Execute(_m);
                    else AnsiConsole.WriteLine("\t wrong command");
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case System.InvalidOperationException or System.OverflowException:
                        #if PROD
                            AnsiConsole.Markup($"[red]ERROR: Wrong PID[/]. Process not found.\n");
                        #endif
                            break;
                        default:
                        #if DEV
                            AnsiConsole.Markup($"[red]ERROR: {ex.Message}[/]\n {ex.InnerException} \n\n {ex.StackTrace}");
                        #endif
                        #if PROD
                            AnsiConsole.Markup($"[red]ERROR: {ex.Message}[/]\n");
                        #endif
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