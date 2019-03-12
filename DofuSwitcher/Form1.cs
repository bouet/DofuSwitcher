using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SET LIST PROPERTIES
            lstProcess.View = View.Details;
            lstProcess.FullRowSelect = true;
            //LOAD LISTS
            loadProcessList();
            loadDofusWindows();
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
            Process[] dofusList = Process.GetProcessesByName("Dofus");
            foreach (Process process in dofusList)
            {
                lstChkDofus.Items.Add(process.MainWindowTitle);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProcessList();
            loadDofusWindows();
        }

        private void lstChkDofus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
