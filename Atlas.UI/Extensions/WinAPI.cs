using System;
using System.Runtime.InteropServices;

namespace Atlas.UI.Extensions
{
    internal static class WinAPI
    {       
        [StructLayout(LayoutKind.Sequential)]
        internal struct Margins
        {
            internal int Left;
            internal int Right;
            internal int Top;
            internal int Bottom;
        }

        [DllImport("dwmapi.dll", PreserveSig = true)]
        internal static extern int DwmSetWindowAttribute(IntPtr handle, int attributes, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        internal static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);
    }
}
