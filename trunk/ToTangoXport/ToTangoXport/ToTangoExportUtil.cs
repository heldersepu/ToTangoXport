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
using absToTango;
using System.Data.SqlClient;


namespace ToTangoXport
{
    public partial class ToTangoXport
    {
        private ToTangoExport toTango;
        public string token = "";
        public string headerFile = "";
        public string baseUrl = "";
        public string outDirectory = "";
        public string SQLConnString = "";
        
        public ToTangoXport()
        {
            InitializeComponent();
            InitializeDialog();
            InitializeTotango();            
        }

        public void InitializeTotango()
        {            
            try
            {
                token = ConfigurationManager.AppSettings.Get("ToTangoToken");
                headerFile = ConfigurationManager.AppSettings.Get("HeaderFile");
                baseUrl = ConfigurationManager.AppSettings.Get("BaseConfirmUrl");
                outDirectory = ConfigurationManager.AppSettings.Get("OutputDirectory");
                SQLConnString = ConfigurationManager.AppSettings.Get("SQLConnString");
            }
            catch (Exception) { }
            if (!File.Exists(headerFile)) 
                File.WriteAllLines(headerFile, new string [] {ConfigurationManager.AppSettings.Get("DefaultCSVHead")});
            toTango = new ToTangoExport(token, headerFile, SQLConnString);
        }

        private void InitializeDialog()
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "ToTango";
            saveFileDialog1.Filter = "ToTango Config|*.ToTango";

            openFileDialog1.AddExtension = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.DefaultExt = "ToTango";
            openFileDialog1.Filter = "ToTango Config|*.ToTango";
            openFileDialog1.FileName = "";
        }

        private void loadFromFile(string FileName)
        {
            if (File.Exists(FileName))
            {
                dataGridView.Rows.Clear();
                foreach (string line in File.ReadAllLines(FileName))
                {
                    dataGridViewRowsAdd(line);
                }
            }
        }

        private void dataGridViewRowsAdd(string line)
        {
            dataGridView.Rows.Add();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value == null)
                {
                    row.Cells[0].Value = line;
                    break;
                }
            }
        }

        private void writeToFile(string FileName)
        {
            List<string> lines = new List<string>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    string url = row.Cells[0].Value.ToString();
                    if (url.Length > 0)
                    {
                        lines.Add(url);
                    }
                }
            }
            File.WriteAllLines(FileName, lines);
        }

        public void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void Download(string url, string outname)
        {
            this.status.Text = "Downloading...";
            this.status2.Text = "";
            this.Refresh();
            outname = this.toTango.Start(url, outDirectory, outname, baseUrl);
            this.status.Text = "Done!";
            this.status2.Text = outname;
        }

        private List<string> GetUrlList()
        {
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(SQLConnString))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(SQLConnString))
                    {
                        SqlCommand command = new SqlCommand("[event].[GetAllCampaigns]", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            list.Add(reader["URL"].ToString());
                        }
                        reader.Close();
                        conn.Close();
                    }
                }
                catch { }
            }
            return list;
        }

        private bool TestSQL()
        {
            bool isOK = false;
            if (!string.IsNullOrEmpty(SQLConnString))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(SQLConnString + ";ConnectTimeout=2"))
                    {                        
                        conn.Open();
                        isOK = true;
                    }
                }
                catch
                {
                    isOK = false;
                }
            }
            return isOK;
        }
    }
}
