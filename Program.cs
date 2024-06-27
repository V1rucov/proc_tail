using proc_tail;
using System.Management;

Modes.Mode mode;

Console.WriteLine("Choose mode: (M to see live. Press any key to take snapshot)");
char m = Console.ReadKey().KeyChar;

switch (m) {
    case 'M':
        mode = Modes.Monitor;
        break;
    default:
        mode = Modes.Snapshot;
        break;
}

Console.WriteLine();
Console.WriteLine("PID:");

int pid = Int32.Parse(Console.ReadLine());
var mos = new ManagementObjectSearcher($"SELECT * FROM Win32_Process WHERE ProcessId = {pid}");
var proc = mos.Get();

mode.Invoke(proc.Cast<ManagementObject>().ToArray().First());