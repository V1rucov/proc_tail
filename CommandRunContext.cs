using proc_tail.Viewers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace proc_tail
{
    public class CommandRunContext
    {
        public AbstractViewer Viewer { get; set; }
        private int _ProcessId = 0;
        private string _ProcessName = null;
        public int? ProcessId {
            get => _ProcessId;
            
            set {
                _ProcessId = value.Value;
            }
        }
        public string ProcessName
        {
            get => _ProcessName;
            set { 
                _ProcessName = value;
            }
        }
    }
}
