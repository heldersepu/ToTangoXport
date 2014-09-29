using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ToTangoXport
{
    public partial class Options : Form
    {
        private ToTangoXport parent;

        public Options(ToTangoXport tparent)
        {
            parent = tparent;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            parent.UpdateSetting("HeaderFile", txbMappingFile.Text);
            parent.UpdateSetting("BaseConfirmUrl", txbConfirmUrl.Text);
            parent.UpdateSetting("ToTangoToken", txbToken.Text);
            parent.UpdateSetting("OutputDirectory", txbOutputDirectory.Text);
            parent.UpdateSetting("SQLConnString", txbSQLConnection.Text);
            parent.UpdateSetting("CopyExport2SQL", BackupY.Checked ? "1" : "0");

            parent.UpdateSetting("DoFTP", FTPUploadY.Checked ? "1" : "0");
            parent.UpdateSetting("FTPServer", txbFTPServer.Text);
            parent.UpdateSetting("FTPUserName", txbFTPUserName.Text);
            parent.UpdateSetting("FTPPassword", txbFTPPassword.Text);
            parent.InitializeTotango();
            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            txbMappingFile.Text = parent.headerFile;
            txbConfirmUrl.Text = parent.baseConfirmUrl;
            txbToken.Text = parent.token;
            txbOutputDirectory.Text = parent.outDirectory;
            txbSQLConnection.Text = parent.SQLConnString;
            BackupY.Checked = parent.CopyExport2SQL;
            BackupN.Checked = !parent.CopyExport2SQL;
            btnTest.Enabled = (txbSQLConnection.Text.Length > 1);

            FTPUploadY.Checked = parent.doFTP;
            FTPUploadN.Checked = !FTPUploadY.Checked;
            txbFTPServer.Text = parent.FTPServer;
            txbFTPUserName.Text = parent.FTPUserName;
            txbFTPPassword.Text = parent.FTPPassword;
            btnTestFTP_change(sender, null);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (parent.TestSQL(txbSQLConnection.Text))
                txbSQLConnection.ForeColor = Color.Green;
            else
                txbSQLConnection.ForeColor = Color.Red;
            btnTest.ForeColor = txbSQLConnection.ForeColor;
        }

        private void txbSQLConnection_KeyDown(object sender, KeyEventArgs e)
        {
            btnTest.ForeColor = Color.Black;
            txbSQLConnection.ForeColor = Color.Black;
            btnTest.Enabled = (txbSQLConnection.Text.Length > 1);
        }

        private void btnTestDir_Click(object sender, EventArgs e)
        {
            if (testOutDir(txbOutputDirectory.Text))
                txbOutputDirectory.ForeColor = Color.Green;
            else
                txbOutputDirectory.ForeColor = Color.Red;
            btnTestDir.ForeColor = txbOutputDirectory.ForeColor;
        }

        private bool testOutDir(string dir)
        {
            bool dirOK = false;
            string tempFile = dir + "\\test.txt";
            try
            {
                if (Directory.Exists(dir))
                {
                    File.WriteAllText(tempFile, "TEST");
                    if (File.Exists(tempFile))
                    {
                        File.Delete(tempFile);
                        dirOK = true;
                    }
                }
            }
            catch
            {
                dirOK = false;
            }            
            return dirOK;
        }

        private void txbOutputDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbOutputDirectory_KeyDown(sender, null);
        }

        private void txbOutputDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            txbOutputDirectory.ForeColor = Color.Black;
            btnTestDir.ForeColor = Color.Black;
        }

        private void btnTestFTP_change(object sender, KeyEventArgs e)
        {
            btnTestFTP.Enabled = ((txbFTPServer.Text.Length > 2) && (txbFTPUserName.Text.Length > 2) && (txbFTPPassword.Text.Length > 2));
            btnTestFTP.ForeColor = Color.Black;
            txbFTPServer.ForeColor = Color.Black;
            txbFTPUserName.ForeColor = Color.Black;
            txbFTPPassword.ForeColor = Color.Black;
        }

        private void btnTestFTP_Click(object sender, EventArgs e)
        {
            btnTestFTP_change(sender, null);
            if (btnTestFTP.Enabled)
            {
                btnTestFTP.ForeColor = Color.Red;
                try
                {
                    string fileName = "test.csv";
                    File.WriteAllText(fileName, "TEST");
                    ftp myFTP = new ftp(txbFTPServer.Text, txbFTPUserName.Text, txbFTPPassword.Text);
                    if (myFTP.upload(fileName, fileName))
                        if (myFTP.delete(fileName))
                            btnTestFTP.ForeColor = Color.Green;
                }
                catch {}                                 
                txbFTPServer.ForeColor = btnTestFTP.ForeColor;
                txbFTPUserName.ForeColor = btnTestFTP.ForeColor;
                txbFTPPassword.ForeColor = btnTestFTP.ForeColor;
            }
        }

    }
}
