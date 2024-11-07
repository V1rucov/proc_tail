using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using proc_tail.Types;
using NTRegistry;

namespace proc_tail.Viewers
{
    internal class RegistryViewer : IViewer<string[]>
    {
        public static UIntPtr HKEY_CURRENT_USER = (UIntPtr)0x80000001;
        public static UIntPtr HKEY_LOCAL_MACHINE = (UIntPtr)0x80000002;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"> 1 - RegistryKey, 2 - path, 3 - name</param>
        /// <returns>name - value</returns>
        public string[] GetSingleObject(string[] args)
        {
            var ntkey = NtRegistry.CurrentUser;
            switch (args[0].Split("\\")[0]) {
                case "HKEY_USERS":
                    ntkey = NtRegistry.Users;
                    break;
                case "HKEY_CURRENT_USER":
                    ntkey = NtRegistry.CurrentUser;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    ntkey = NtRegistry.LocalMachine;
                    break;
            }

            string[] result = {"",""};
            result[0] = args[0];
            Console.WriteLine(args[0]);
            ntkey.OpenSubKey(args[0].Replace(args[0].Split("\\").Last(),""));
            result[1] = ntkey.GetValue(args[0].Split("\\").Last()).ToString();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"> 1 - RegistryKey, 2 - path</param>
        /// <returns>List of 'name - value'</returns>
        public List<string[]> GetManyObjects(string[] args)
        {
            var key = NtRegistry.CurrentUser;
            switch (args[0])
            {
                case "HKEY_USERS":
                    key = NtRegistry.Users;
                    break;
                case "HKEY_CURRENT_USER":
                    key = NtRegistry.CurrentUser;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    key = NtRegistry.LocalMachine;
                    break;
            }

            List<string[]> results = new List<string[]>();

            var keys = key.OpenSubKey(args[1]);
            foreach (var cc in keys.GetValueNames())
            {
                string value = keys.GetValue(cc)?.ToString() ?? "hidden";
                results.Add(new string[] { $"{args[0]}\\{args[1]}\\{cc}", value });
            }
            key.Close();
            return results;
        }
    }
}
