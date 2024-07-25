using System;
using proc_tail.Commands;
using proc_tail.Viewers;
using Spectre.Console;

namespace proc_tail {
    public static class Program {
        static AbstractCommand command;
        static AbstractViewer Viewer;
        static ApplicationContext Context = new ApplicationContext();

        static DictionaryWithDefault<char, AbstractCommand> Commands = new DictionaryWithDefault<char, AbstractCommand>() {
            {'A', new AnalyzeRegistryCommand(Viewer, Context) },
            {'L', new MonitorCommand(Viewer, Context) },
            {'S', new SnapshotCommand(Viewer, Context) }
        };

        static DictionaryWithDefault<char, AbstractViewer> Sources = new DictionaryWithDefault<char, AbstractViewer>() {
            {'J', new JournalViewer() },
            {'W', new WMIViewer() }
        };

        static Panel Header = new Panel("[yellow]An process inspection tool\nAuthor - V1rucov \ngithub - https://github.com/V1rucov/proc_tail[/]");

        public static void Main() {
            Header.Header = new PanelHeader("proc_tail");
            AnsiConsole.Write(Header);

            while (true)
            {
                try
                {
                    char m = AnsiConsole.Ask<char>("What to do?: \n\tPress L to start live-mode. \n\tPress S to take snapshot. \n\tPress A to analyzer process's execution origin");
                    command = Commands[m];

                    char src = AnsiConsole.Ask<char>("Choose source: \n\tJ to inspect security journal. \n\tW to inspect live processes.");
                    command.Viewer = Sources[src];

                    Context.ProcessId = AnsiConsole.Ask<int?>("PID: ");
                    Context.ProcessName = AnsiConsole.Ask<string>("Process name (only for journal source): ");

                    command.Execute();
                }
                catch (Exception ex)
                {
                    switch (ex)
                    {
                        case System.InvalidOperationException or System.OverflowException:
                            AnsiConsole.Markup("[red]ERROR: wrong PID. Process not found.[/]");
                            break;
                        default:
                            AnsiConsole.Markup($"[red]ERROR: {ex.Message}[/]\n");
                            break;
                    }
                    AnsiConsole.Write(new Rule());
                }
            }
        }
    }
}