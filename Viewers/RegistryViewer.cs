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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"> 1 - RegistryKey</param>
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
            var splitted = args[0].Split("\\");
            List<string> middlePath = splitted.Skip(1).SkipLast(2).ToList();
            string path = string.Join("\\", middlePath);
            string name = splitted[splitted.Count() - 2];
            if (middlePath.Count() < 2) path = middlePath[0];

            var subkey = ntkey.OpenSubKey(path);

            string[] result = {"",""};
            result[0] = args[0];

            foreach (var item in subkey.GetValueNames()) 
                if (item.Contains(name)) 
                    result[1] = subkey.GetValue(item)?.ToString();
            
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"> 1 - RegistryKey, 2 - path</param>
        /// <returns>List of 'name - value'</returns>
        public List<string[]> GetManyObjects(string[] args)
        {
            var key = Registry.CurrentUser;
            switch (args[0])
            {
                case "HKEY_USERS":
                    key = Registry.Users;
                    break;
                case "HKEY_CURRENT_USER":
                    key = Registry.CurrentUser;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    key = Registry.LocalMachine;
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
