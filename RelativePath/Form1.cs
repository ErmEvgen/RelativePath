using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelativePath
{
    public partial class Form1 : Form
    {
        public string resPath;
        public string resFolder;
        public int res;
        public Form1()
        {
            
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {


            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                resPath = openFileDialog1.FileName;
                res = 1;
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog
            {


            };

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                resFolder = folderBrowserDialog1.SelectedPath;
                res = 2;
            }

            this.Close();
        }
    }
}
