using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DofuSwitcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int SetActiveWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int SetWindowsHookEx(
            int idHook,
            HookProc lpfn,
            IntPtr hMod,
            int dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
                    CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int CallNextHookEx(
            int idHook,
            int nCode,
            int wParam,
            IntPtr lParam);

        [DllImport("user32")]
        private static extern int ToAscii(
            int uVirtKey,
            int uScanCode,
            byte[] lpbKeyState,
            byte[] lpwTransKey,
            int fuState);

        [DllImport("user32")]
        private static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern short GetKeyState(int vKey);

        private delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private class POINT
        {
            /// <summary>
            /// Coordonnée X. 
            /// </summary>
            public int x;
            /// <summary>
            /// Coordonnée Y.
            /// </summary>
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class MouseHookStruct
        {
            /// <summary>
            /// Structure POINT pour les coordonnée 
            /// </summary>
            public POINT pt;
            /// <summary>
            /// Handle de la window
            /// </summary>
            public int hwnd;
            /// <summary>
            /// Specifies the hit-test value. For a list of hit-test values, see the description of the WM_NCHITTEST message. 
            /// </summary>
            public int wHitTestCode;
            /// <summary>
            /// Specifies extra information associated with the message. 
            /// </summary>
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class MouseLLHookStruct
        {
            /// <summary>
            /// Structure POINT.
            /// </summary>
            public POINT pt;
            public int mouseData;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private class KeyboardHookStruct
        {
            /// <summary>
            /// Key code virtuel, la valeur doit etre entre 1 et 254. 
            /// </summary>
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        //Valeurs issues de Winuser.h du SDK de Microsoft.
        /// <summary>
        /// Windows NT/2000/XP: Installe un hook pour la souris
        /// </summary>
        private const int WH_MOUSE_LL = 14;
        /// <summary>
        /// Windows NT/2000/XP: Installe un hook pour le clavier
        /// </summary>
        private const int WH_KEYBOARD_LL = 13;

        private const int WH_MOUSE = 7;

        private const int WH_KEYBOARD = 2;

        /// <summary>
        /// Le message WM_MOUSEMOVE est envoyé quand la souris bouge
        /// </summary>
        private const int WM_MOUSEMOVE = 0x200;
        /// <summary>
        /// Le message WM_LBUTTONDOWN est envoyé lorsque le bouton gauche est pressé
        /// </summary>
        private const int WM_LBUTTONDOWN = 0x201;
        /// <summary>
        /// Le message WM_RBUTTONDOWN est envoyé lorsque le bouton droit est pressé
        /// </summary>
        private const int WM_RBUTTONDOWN = 0x204;
        /// <summary>
        /// Le message WM_MBUTTONDOWN est envoyé lorsque le bouton central est pressé
        /// </summary>
        private const int WM_MBUTTONDOWN = 0x207;
        /// <summary>
        /// Le message WM_LBUTTONUP est envoyé lorsque le bouton gauche est relevé
        /// </summary>
        private const int WM_LBUTTONUP = 0x202;
        /// <summary>
        /// Le message WM_RBUTTONUP est envoyé lorsque le bouton droit est relevé 
        /// </summary>
        private const int WM_RBUTTONUP = 0x205;

        private const int WM_MBUTTONUP = 0x208;

        private const int WM_LBUTTONDBLCLK = 0x203;

        private const int WM_RBUTTONDBLCLK = 0x206;

        private const int WM_MBUTTONDBLCLK = 0x209;

        private const int WM_MOUSEWHEEL = 0x020A;


        private const int WM_KEYDOWN = 0x100;

        private const int WM_KEYUP = 0x101;

        private const int WM_SYSKEYDOWN = 0x104;

        private const int WM_SYSKEYUP = 0x105;

        private const byte VK_SHIFT = 0x10;
        private const byte VK_CAPITAL = 0x14;
        private const byte VK_NUMLOCK = 0x90;


        List<string> listDofusWindows = new List<string>();


        public IntPtr findMe()
        {
            return this.Handle; //FindWindow("", "Form1");
        }

        public int MakeLParam(int LoWord, int HiWord)
        {
            return ((HiWord << 16) | (LoWord & 0xffff));
        }

        private void Start()
        {
            int coordinates = Cursor.Position.X | (Cursor.Position.Y << 16);
            foreach (string window in listDofusWindows)
            {
                IntPtr _pointer = FindWindow(null, window);
                SetForegroundWindow(_pointer);
                SendMessage(_pointer, (int)WM_LBUTTONDOWN, 0, coordinates);
                SendMessage(_pointer, (int)WM_LBUTTONUP, 0, coordinates);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SET LIST PROPERTIES
            lstProcess.View = View.Details;
            lstProcess.FullRowSelect = true;
            //LOAD LISTS
            loadProcessList();
            loadDofusWindows();
            //Console
            loadConsole();
        }

        private void loadProcessList()
        {
            lstProcess.Items.Clear();
            Process[] processList = Process.GetProcesses();
            foreach (Process process in processList)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(Convert.ToString(process.Id));
                lstProcess.Items.Add(item);
            }
        }

        private void loadDofusWindows()
        {
            lstChkDofus.Items.Clear();
            listDofusWindows.Clear();
            Process[] dofusList = Process.GetProcessesByName("Dofus");
            foreach (Process process in dofusList)
            {
                lstChkDofus.Items.Add(process.MainWindowTitle);
                //lstChkDofus.Items.Add(process.Id);
                listDofusWindows.Add(process.MainWindowTitle);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProcessList();
            loadDofusWindows();

            //Console
            loadConsole();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        //Console.WriteLine
        private void loadConsole()
        {
            lstConsole.Items.Clear();
            foreach (String window in listDofusWindows)
            {
                lstConsole.Items.Add(window);
            }
        }
    }
}