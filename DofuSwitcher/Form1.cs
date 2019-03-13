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

        public enum WMessages : int
        {
            WM_LBUTTONDOWN = 0x201, //Left mousebutton down
            WM_LBUTTONUP = 0x202, //Left mousebutton down
            WM_LBUTTONDBLCLK = 0x203, //Left mousebutton doubleclick
            WM_RBUTTONDOWN = 0x204, //Right mousebutton down
            WM_RBUTTONUP = 0x205, //Right mousebutton down
            WM_RBUTTONDBLCLK = 0x206, //Right mousebutton doubleclick
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

        public IntPtr findMe()
        {
            return this.Handle; //FindWindow("", "Form1");
        }

        public int MakeLParam(int LoWord, int HiWord)
        {
            return ((HiWord << 16) | (LoWord & 0xffff));
        }


        /*
        private void Start()
        {
            foreach(string window in listDofusWindows)
            {
                IntPtr _pointer = FindWindow(null, window);
                SetForegroundWindow(_pointer);
                int LParam = MakeLParam(900, 1100);
                PostMessage(_pointer, (int)WMessages.WM_RBUTTONDOWN, 0, LParam);
                PostMessage(_pointer, (int)WMessages.WM_RBUTTONUP, 0, LParam);
            }
        }
        */

        private bool _start;

        private void Start()
        {
            int coordinates = Cursor.Position.X | (Cursor.Position.Y << 16);
            //_start = true;
            //while (_start)
            //{
                foreach (string window in listDofusWindows)
                {
                    IntPtr _pointer = FindWindow(null, window);
                    SetForegroundWindow(_pointer);
                    SendMessage(_pointer, (int)WMessages.WM_LBUTTONDOWN, 0, coordinates);
                    SendMessage(_pointer, (int)WMessages.WM_LBUTTONUP, 0, coordinates);
                }
            //}
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


        List<string> listDofusWindows = new List<string>();

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

        //Console.WriteLine
        private void loadConsole()
        {
            lstConsole.Items.Clear();
            foreach (String window in listDofusWindows)
            {
                lstConsole.Items.Add(window);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProcessList();
            loadDofusWindows();

            //Console
            loadConsole();
        }

        private void lstChkDofus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //FUNCTION TO CLICK

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public void Clicker(int x, int y)
        {
            SetCursorPos(x, y);
            this.Refresh();
            Application.DoEvents();
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _start = false;
        }
    }
}