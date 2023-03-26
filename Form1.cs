using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace VMwareTimeSyncDisabler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            using (StreamWriter stream = File.AppendText(openFileDialog1.FileName))
            {
                stream.WriteLine("time.synchronize.continue = \"FALSE\"");
                stream.WriteLine("time.synchronize.restore = \"FALSE\"");
                stream.WriteLine("time.synchronize.resume.disk = \"FALSE\"");
                stream.WriteLine("time.synchronize.shrink = \"FALSE\"");
                stream.WriteLine("time.synchronize.tools.startup = \"FALSE\"");
                stream.WriteLine("time.synchronize.tools.enable = \"FALSE\"");
                stream.WriteLine("time.synchronize.resume.host = \"FALSE\"");
            }
            MessageBox.Show("Time sync disabled");
        }
    }
}
