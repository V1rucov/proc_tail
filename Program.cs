﻿#define DEV

using proc_tail.Commands;
using proc_tail.OutputFormats;
using proc_tail.TI;
using Spectre.Console;

namespace proc_tail {
    public static class Program {
        static AbstractCommand command;
        static AbstractOutputFormat outputFormat = new ConsoleOutput();
        public static Grid CurrentGrid = new Grid();

        static List<AbstractCommand>? Commands = new List<AbstractCommand>() {
            new AnalyzeRegistryCommand(outputFormat),
            new EasterEggCommand(outputFormat),
            new ProcessListCommand(outputFormat),
            new TreeSnapshotCommand(outputFormat),
            new ServiceListCommand(outputFormat),
            new TaskListCommand(outputFormat),
            new WMISubscriptionsListCommand(outputFormat),
            new ScanCommand(outputFormat),
            new StartupFolderListCommand(outputFormat),
            new CheckHashCommand(outputFormat)
        };

        static Panel Header = new Panel("[yellow]Persistent malware searcher for Windows\nAuthor - V1rucov \ngithub - https://github.com/V1rucov/proc_tail[/]");

        public static void Main() {
            Header.Header = new PanelHeader("proc_tail");
            AnsiConsole.Write(Header);

            while (true)
            {
                try
                {
                    string _m = AnsiConsole.Ask<string>($"[yellow]{Environment.UserName}[/]:> ");
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
                            Console.WriteLine($"ERROR: {ex.Message}\n {ex?.InnerException} \n\n {ex?.StackTrace}");
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