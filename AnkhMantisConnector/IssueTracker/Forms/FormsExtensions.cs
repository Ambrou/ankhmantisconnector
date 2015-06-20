using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AnkhMantisConnector.IssueTracker.Forms
{
    static class FormsExtensions
    {

        public static void SuspendDrawing(this Control target)
        {
            NativeMethods.SendMessage(target.Handle, NativeMethods.WM_SETREDRAW, 0, 0);
        }

        public static void ResumeDrawing(this Control target)
        {
            ResumeDrawing(target, true);
        }

        public static void ResumeDrawing(this Control target, bool redraw)
        {
            NativeMethods.SendMessage(target.Handle, NativeMethods.WM_SETREDRAW, 1, 0);

            if (redraw)
            {
                target.Refresh();
            }
        }

        private static class NativeMethods
        {
            [DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi,
                SetLastError = true)]
            public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

            public const int WM_SETREDRAW = 0xB;
        }
    }
}
