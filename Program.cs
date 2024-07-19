using proc_tail;
using proc_tail.Commands;
using proc_tail.Viewers;
using Spectre.Console;

AbstractCommand command;
AbstractViewer viewer;
ApplicationContext Context = new ApplicationContext();

Panel Header = new Panel("[yellow]An process inspection tool\nAuthor - V1rucov \ngithub - https://github.com/V1rucov/proc_tail[/]");
AnsiConsole.Write(Header);

while (true)
{
    try
    {
        char src = AnsiConsole.Ask<char>("Choose source: \n\tJ to inspect security journal. \n\tAny key to inspect live processes.");
        switch (src) {
            case 'J':
                viewer = new JournalViewer();
                break;
            default:
                viewer = new Win32Viewer();
                break;
        }

        char m = AnsiConsole.Ask<char>("What to do?: \n\tPress L to start live-mode. \n\tPress any key to take snapshot");
        switch (m)
        {
            case 'L':
                command = new SnapshotCommand(viewer, Context);
                Console.WriteLine("Monitor mode.");
                break;
            default:
                command = new SnapshotCommand(viewer, Context);
                Console.WriteLine("Snapshot mode.");
                break;
        }

        Context.ProcessId = AnsiConsole.Ask<int?>("PID: ");
        Context.ProcessName = AnsiConsole.Ask<string>("Process name (only for journal source): ");

        command.Execute();
    }
    catch (Exception ex)
    {
        switch (ex)
        {
            case System.FormatException:
                AnsiConsole.Write("[red]ERROR: wrong PID format. Number expected (not string).[/]");
                break;
            case System.InvalidOperationException or System.OverflowException:
                AnsiConsole.Write("[red]ERROR: wrong PID. Process not found.[/]");
                break;
        }

        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.InnerException);
        Console.WriteLine(ex.GetType().FullName);
        Console.WriteLine(ex.StackTrace);
    }
}

