using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STFGUI
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.pathToAtomicParsley = parsleyPath.Text;
            Properties.Settings.Default.pathToHandbrake = handbrakePath.Text;
            Properties.Settings.Default.pathToMP4Box = mp4boxPath.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.RestoreDirectory = true;
            fileDialog1.Multiselect = false;
            fileDialog1.Filter = "Executable Files (*.exe)|*.exe";
            if (fileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                handbrakePath.Text = fileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.RestoreDirectory = true;
            fileDialog1.Multiselect = false;
            fileDialog1.Filter = "Executable Files (*.exe)|*.exe";
            if (fileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mp4boxPath.Text = fileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.RestoreDirectory = true;
            fileDialog1.Multiselect = false;
            fileDialog1.Filter = "Executable Files (*.exe)|*.exe";
            if (fileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                parsleyPath.Text = fileDialog1.FileName;
            }
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            handbrakePath.Text = Properties.Settings.Default.pathToHandbrake;
            parsleyPath.Text = Properties.Settings.Default.pathToAtomicParsley;
            mp4boxPath.Text = Properties.Settings.Default.pathToMP4Box;
        }
    }
}
