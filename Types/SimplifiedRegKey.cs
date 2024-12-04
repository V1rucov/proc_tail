using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    public class SimplifiedRegKey : IDisplayable
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string[] GetStringCol() => new string[] { "Key", "Value" };
        public string[] GetStringRow() => new string[] { Key, Value };

        public static implicit operator SimplifiedRegKey(string[] RegKey)
        {
            SimplifiedRegKey srk = new SimplifiedRegKey();
            srk.Key = RegKey[0];
            srk.Value = RegKey[1];

            return srk;
        }
    }
}
