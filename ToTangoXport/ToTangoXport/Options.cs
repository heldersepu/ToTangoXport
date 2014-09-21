using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToTangoXport
{
    public partial class Options : Form
    {
        ToTangoXport parent;
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
        }
    }
}
