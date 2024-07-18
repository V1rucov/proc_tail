using proc_tail;
using proc_tail.Commands;
using proc_tail.Viewers;
using System.Diagnostics;
using System.Management;
using System.Runtime.CompilerServices;
using System.Windows.Input;

AbstractCommand command;
AbstractViewer viewer;
ApplicationContext Context = new ApplicationContext();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("proc_tail, an process inspection tool \nAuthor - V1rucov \ngithub - https://github.com/V1rucov/proc_tail");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();

while (true)
{
    try
    {
        Console.WriteLine("Choose source: \n\tPress J to inspect security journal. \n\tPress any key to inspect live processes.");
        char src = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (src) {
            case 'J':
                viewer = new JournalViewer();
                break;
            default:
                viewer = new Win32Viewer();
                break;
        }

        Console.WriteLine("What to do?: \n\tPress L to start live-mode. \n\tPress J to inspect security journal. \n\tPress any key to take snapshot");
        char m = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (m)
        {
            case 'L':
                command = new SnapshotCommand(viewer, Context);
                Console.WriteLine("Monitor mode.");
                break;
            case 'J':
                command = new SnapshotCommand(viewer, Context);
                Console.WriteLine("Journal inspection mode.");
                break;
            default:
                command = new SnapshotCommand(viewer, Context);
                Console.WriteLine("Snapshot mode.");
                break;
        }

        Console.WriteLine("PID:");
        Context.ProcessId = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Process name (not necessary):");
        Context.ProcessName = Console.ReadLine();

        command.Execute();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        switch (ex)
        {
            case System.FormatException:
                Console.WriteLine("ERROR: wrong PID format. Number expected (not string).");
                break;
            case System.InvalidOperationException or System.OverflowException:
                Console.WriteLine("ERROR: wrong PID. Process not found.");
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;

        //Console.WriteLine(ex.Message);
        //Console.WriteLine(ex.InnerException);
        //Console.WriteLine(ex.GetType().FullName);

        Console.WriteLine();
    }
}

