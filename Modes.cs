using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace proc_tail
{
    public partial class Program
    {
        public static List<ManagementObject> GetParents(ManagementObject proc) {
            List<ManagementObject> managementObjects = new List<ManagementObject>();

            var mos = new ManagementObjectSearcher($"SELECT * FROM Win32_Process WHERE ProcessId = {proc["ParentProcessId"]}");
            ManagementObjectCollection _parent = mos.Get();
            if (_parent.Count != 0) {
                ManagementObject parent = _parent.Cast<ManagementObject>().ToArray().First();

                managementObjects.Add(parent);
                managementObjects.AddRange(GetParents(parent));
            }
            return managementObjects;
        }
    }

    public static class Modes
    {
        public delegate void Mode(ManagementObject proc);
        public static void Snapshot(ManagementObject proc)
        {
            Console.WriteLine($"Process: {proc["Name"]}");
            Console.WriteLine();

            var parents = Program.GetParents(proc);
            parents.Reverse();
            parents.Add(proc);

            List<SimplifiedProcess> sp = new List<SimplifiedProcess>();
            parents.ForEach(p => { sp.Add((SimplifiedProcess)p); });

            for (int i = 0; i < sp.Count-1; i++)
            {
                sp[i].Children = new SimplifiedProcess[1] { sp[i+1] };
            }
            var md = MD5.Create();
            string path = AppDomain.CurrentDomain.BaseDirectory + Convert.ToHexString(md.ComputeHash(Encoding.UTF8.GetBytes($"{sp[0].Name}{sp[0].Pid}"))) +".json";

            Console.WriteLine($"Json file created at {path}");

            StreamWriter sw = new StreamWriter(path);
            sw.Write(JsonSerializer.Serialize(sp[0]));
            sw.Close();
        }
        public static void Monitor(ManagementObject proc)
        {
            Console.WriteLine("Coming soon...");
        }
    }
}
