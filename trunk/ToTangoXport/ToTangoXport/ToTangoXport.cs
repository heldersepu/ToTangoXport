using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ToTangoXport
{
    public partial class ToTangoXport : Form
    {
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = ((DataGridView)(sender)).CurrentCell;
            if (cell.ColumnIndex == 1)
            {
                DataGridViewRow row = ((DataGridView)(sender)).CurrentRow;
                if (row.Cells[0].Value != null)
                {
                    string url = row.Cells[0].Value.ToString();
                    if (url.Length > 0)
                    {
                        this.Download(url, cell.RowIndex.ToString() + ".csv");
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 1)
                this.status.Text = "Nothing to save...";
            else
            {
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    this.writeToFile(saveFileDialog1.FileName);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                this.loadFromFile(openFileDialog1.FileName);
                this.UpdateSetting("LastOpenFile", openFileDialog1.FileName);
            }
        }

        private void ToTangoXport_Load(object sender, EventArgs e)
        {
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg.StartsWith("url="))
                {
                    this.Download(arg.Replace("url=",""), "download.csv");
                    this.Close();
                }
            }            
            string lastFile = ConfigurationManager.AppSettings.Get("LastOpenFile");
            if (lastFile != "")
                this.loadFromFile(lastFile);
        }

        private void status2_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.status2.Text))
            {
                System.Diagnostics.Process.Start(this.status2.Text);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options f2 = new Options(this);
            f2.Show();
        }

        private void testConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.status.Text = "Testing SQL connection...";
            if (TestSQL())
            {
                this.status.Text = "Test passed, connection is OK!";
                MessageBox.Show("Test passed, connection is OK!", "ToTangoXport", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.status.Text = "Test failed!";
                MessageBox.Show("Test failed!", "ToTangoXport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getCampaignsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> list = GetUrlList();
            if (list.Count > 0)
            {
                dataGridView.Rows.Clear();
                foreach (string url in list)
                {
                    dataGridViewRowsAdd(url);
                }
            }
            else
            {
                this.status.Text = "No data received from SQL!";
                MessageBox.Show("No data received from SQL!", "ToTangoXport", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }


        private string outputName;
        private string downloadURL;
        private void Download(string url, string outname)
        {
            dataGridView.Enabled = false;
            if (!backgroundWorker.IsBusy)
            {
                outputName = outname;
                downloadURL = url;
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.status.Text = "Downloading...";
            this.status2.Text = "";
            outputName = this.toTango.Start(downloadURL, outDirectory, outputName, baseUrl);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Refresh();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.Enabled = true;
            this.status.Text = "Done!";
            this.status2.Text = outputName;
        }
    }
}
