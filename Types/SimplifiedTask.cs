﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace proc_tail.Types
{
    //TODO: simplified task
    public class SimplifiedTask : IDisplayable
    {

        public string[] GetStringCol()
        {
            throw new NotImplementedException();
        }

        public string[] GetStringRow()
        {
            throw new NotImplementedException();
        }

        public static implicit operator SimplifiedTask(Microsoft.Win32.TaskScheduler.Task task)
        {
            SimplifiedTask st = new SimplifiedTask();
            

            return st;
        }
    }
}
