using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KlonsLIB.Components
{
    public static class NM
    {
        public const int WM_ERASEBKGND = 0x14;
        public const int WM_PAINT = 0xF;
        public const int WM_NCPAINT = 0x85;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_PRINTCLIENT = 0x318;


        [DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "SendMessageA", ExactSpelling = true, SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hRgn, int flags);

        [DllImport("user32")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT { public int Left, Top, Right, Bottom; }

        [StructLayout(LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            public RECT rcNewWindow;
            public RECT rcOldWindow;
            public RECT rcClient;
            IntPtr lppos;
        }

        public static int HIWORD(IntPtr n) => HIWORD(unchecked((int)(long)n));
        public static int HIWORD(int n) => (n >> 16) & 0xffff;
        public static int LOWORD(int n) => n & 0xffff;
        public static int LOWORD(IntPtr n) => LOWORD(unchecked((int)(long)n));
        public static int SignedHIWORD(IntPtr n) => SignedHIWORD(unchecked((int)(long)n));
        public static int SignedLOWORD(IntPtr n) => SignedLOWORD(unchecked((int)(long)n));
        public static int SignedHIWORD(int n) => (int)(short)((n >> 16) & 0xffff);
        public static int SignedLOWORD(int n) => (int)(short)(n & 0xFFFF);


    }
}
