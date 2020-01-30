using System;

namespace Tomas.Kernel
{
    public delegate void TerminalCancelEventHandler(object sender, TerminalCancelEventArgs e);

    public sealed class TerminalCancelEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
    }
}
