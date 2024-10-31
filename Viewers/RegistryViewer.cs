using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using proc_tail.Types;

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
            RegistryKey subkey = Registry.CurrentUser;
            switch (args[0]) {
                case "HKEY_USERS":
                    subkey = Registry.Users;
                    break;
                case "HKEY_CURRENT_USER":
                    subkey = Registry.CurrentUser;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    subkey = Registry.LocalMachine;
                    break;
            }

            string[] result = {"",""};
            result[0] = args[0] + " - " + args[1];
            result[1] = subkey.OpenSubKey(args[1]).GetValue(args[2]).ToString();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"> 1 - RegistryKey, 2 - path</param>
        /// <returns>List of 'name - value'</returns>
        public List<string[]> GetManyObjects(string[] args)
        {
            UIntPtr keyPointer = HKEY_LOCAL_MACHINE;
            RegistryKey subkey = Registry.CurrentUser;
            switch (args[0])
            {
                case "HKEY_USERS":
                    subkey = Registry.Users;
                    break;
                case "HKEY_CURRENT_USER":
                    subkey = Registry.CurrentUser;
                    keyPointer = HKEY_CURRENT_USER;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    subkey = Registry.LocalMachine;
                    break;
            }

            List<string[]> results = new List<string[]>();

            var keys = subkey.OpenSubKey(args[1]);
            foreach (var cc in keys.GetValueNames())
            {
                string value = keys.GetValue(cc)?.ToString() ?? "Hidden or Empty Value";
                results.Add(new string[] { $"{args[0]}\\{args[1]}\\{cc}", value });
            }
            return results;
        }
    }
}
