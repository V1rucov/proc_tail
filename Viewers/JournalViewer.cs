﻿using System;
using System.Diagnostics;

namespace proc_tail.Viewers
{
    public class JournalViewer : AbstractViewer
    {
        public override SimplifiedProcess GetProcessInfo(int ProcessId, string ProcessName = null)
        {
            return null;
        }
    }
}
