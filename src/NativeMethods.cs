using System;
using System.Security;
using System.Runtime.InteropServices;

namespace GlassWindow
{
    [SuppressUnmanagedCodeSecurity]
    public static class NativeMethods
    {
        /// https://docs.microsoft.com/en-us/windows/desktop/api/uxtheme/ns-uxtheme-_margins
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public struct POINT
        {
            public int X;
            public int Y;
        }


        /// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getactivewindow
        [DllImport("User32.dll")]
        public static extern IntPtr GetActiveWindow();

        /// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowlonga
        [DllImport("User32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        /// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowlonga
        [DllImport("User32.dll")]
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        /// https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getcursorpos
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

        /// https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getcursorpos
        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT rect);

        /// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowpos
        [DllImport("User32.dll")]
        public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        /// https://docs.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-getcursorpos
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out POINT lpPoint);

        /// https://docs.microsoft.com/en-us/windows/desktop/api/dwmapi/nf-dwmapi-dwmextendframeintoclientarea
        [DllImport("Dwmapi.dll")]
        public static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        public static int GWL_STYLE   => -16;
        public static int GWL_EXSTYLE => -20;

        public static uint WS_POPUP => 0x80000000;
        public static uint WS_CAPTION => 0x00C00000;
        public static uint WS_EX_LAYERD = 0x080000;
        public static uint WS_EX_TRANSPARENT = 0x00000020;
        public static uint WS_EX_LEFT => 0x00000000;

        public static MARGINS EXTENT_MARGIN => new MARGINS()
        {
            cxLeftWidth = -1
        };

        public static IntPtr HWND_TOPMOST => new IntPtr(-1);
        public static IntPtr HWND_NOTOPMOST => new IntPtr(-2);
        public static uint SWP_NOSIZE => 0x0001;
        public static uint SWP_NOMOVE => 0x0002;
        public static uint SWP_NOACTIVE => 0x0010;
        public static uint SWP_DRAWFRAME => 0x0020;
        public static uint SWP_SHOWWINDOW => 0x0040;
    }
}