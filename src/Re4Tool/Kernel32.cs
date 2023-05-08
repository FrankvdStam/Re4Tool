using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Re4Tool
{
    public static class Kernel32
    {
        //Win32 API method import to write memory by a process's handle
        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out uint lpNumberOfBytesWritten);

        //Extension method
        public static void WriteMemory(this Process process, long address, byte[] buffer)
        {
            WriteProcessMemory(process.Handle, (IntPtr)address, buffer, (uint)buffer.Length, out _);
        }
    }
}
