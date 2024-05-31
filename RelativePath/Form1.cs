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
            }

            this.Close();
        }
    }
}
