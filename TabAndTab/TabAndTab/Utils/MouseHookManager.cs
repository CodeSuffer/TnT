/* Code By Codesuffer */
/* Computer Science 20143035 */
/* To OSS Team Project */
/* Class for low level mouse hooking */

using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace TabAndTab
{
    class MouseHookManager
    {
        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);
        public delegate void MouseHookEventHandle(Point mouse);
        static int hHook = 0;
        public const int WH_MOUSE_LL = 14;
        public const int WH_LBUTTONUP = 0x0202;
        static HookProc MouseHookProcedure;
        public static event MouseHookEventHandle OnMouseProc;
        public static event MouseHookEventHandle OnMouseLeftUp;

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);


        public static void SetHook()
        {
            if (hHook == 0)
            {
                MouseHookProcedure = new HookProc(MouseHookProc);

                hHook = SetWindowsHookEx(WH_MOUSE_LL,
                                          MouseHookProcedure,
                                          (IntPtr)0,
                                          0);
            }
        }

        public static void UnSetHook()
        {
            if (hHook != 0)
            {
                bool ret = UnhookWindowsHookEx(hHook);
                if (ret == false) return;
                hHook = 0;
            }
        }

        public static int MouseHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            else
            {
                MouseHookManager.MouseHookStruct MyMouseHookStruct =
                                        (MouseHookManager.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookManager.MouseHookStruct));
                if (OnMouseProc != null) OnMouseProc(new Point(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y));
                if (wParam == WH_LBUTTONUP && OnMouseLeftUp != null) OnMouseLeftUp(new Point(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y));

                return CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }
    }
}
