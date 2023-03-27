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
            // Define the lines to be written
            List<string> newLines = new List<string>()
                {
                    "time.synchronize.continue = \"FALSE\"",
                    "time.synchronize.restore = \"FALSE\"",
                    "time.synchronize.resume.disk = \"FALSE\"",
                    "time.synchronize.shrink = \"FALSE\"",
                    "time.synchronize.tools.startup = \"FALSE\"",
                    "time.synchronize.tools.enable = \"FALSE\"",
                    "time.synchronize.resume.host = \"FALSE\"",
                };

            // Read existing lines from the file
            List<string> existingLines = new List<string>();
            if (File.Exists(openFileDialog1.FileName))
            {
                existingLines = File.ReadAllLines(openFileDialog1.FileName).ToList();
            }

            // Append new lines that are not already in the file
            List<string> addedLines = new List<string>();
            foreach (string line in newLines)
            {
                if (!existingLines.Contains(line))
                {
                    existingLines.Add(line);
                    addedLines.Add(line);
                }
            }

            // Write updated lines to the file
            using (StreamWriter stream = new StreamWriter(openFileDialog1.FileName))
            {
                foreach (string line in existingLines)
                {
                    stream.WriteLine(line);
                }
            }

            // Show message box if lines were added
            if (addedLines.Count > 0)
            {
                MessageBox.Show("Time sync disabled succesfully");
            }
            else
            {
                MessageBox.Show("Time sync was already disabled for this file");
            }
        }
    }
}
