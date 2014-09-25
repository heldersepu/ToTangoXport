using System;
using System.Drawing;
using System.Windows.Forms;

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
            parent.InitializeTotango();
            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            txbMappingFile.Text = parent.headerFile;
            txbConfirmUrl.Text = parent.baseUrl;
            txbToken.Text = parent.token;
            txbOutputDirectory.Text = parent.outDirectory;
            txbSQLConnection.Text = parent.SQLConnString;
            BackupY.Checked = parent.CopyExport2SQL;
            BackupN.Checked = !parent.CopyExport2SQL;
            btnTest.Enabled = (txbSQLConnection.Text.Length > 1);
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
    }
}
