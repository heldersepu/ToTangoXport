﻿using System;
using System.IO;
using absToTango;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace ToTangoXport
{
    public partial class ToTangoXport
    {
        private ToTangoExport toTango;
        public string token = "";
        public string headerFile = "";
        public string baseConfirmUrl = "";
        public string outDirectory = "";
        public string SQLConnString = "";
        public bool CopyExport2SQL = false;
        public bool doFTP = false;
        public string FTPServer = "";
        public string FTPUserName = "";
        public string FTPPassword = "";

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
                baseConfirmUrl = ConfigurationManager.AppSettings.Get("BaseConfirmUrl");
                outDirectory = ConfigurationManager.AppSettings.Get("OutputDirectory");
                SQLConnString = ConfigurationManager.AppSettings.Get("SQLConnString");
                CopyExport2SQL = (ConfigurationManager.AppSettings.Get("CopyExport2SQL") == "1");

                doFTP = (ConfigurationManager.AppSettings.Get("DoFTP") == "1");
                FTPServer = ConfigurationManager.AppSettings.Get("FTPServer");
                FTPUserName = ConfigurationManager.AppSettings.Get("FTPUserName");
                FTPPassword = ConfigurationManager.AppSettings.Get("FTPPassword");
                if (!Directory.Exists(outDirectory))
                    Directory.CreateDirectory(outDirectory);
            }
            catch (Exception e)
            {
                nlog.SaveException(e);
            }
            if (!File.Exists(headerFile)) 
                File.WriteAllLines(headerFile, new string [] {ConfigurationManager.AppSettings.Get("DefaultCSVHead")});
            toTango = new ToTangoExport(token, headerFile, (CopyExport2SQL ? SQLConnString : ""));
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
            line = line.Trim();
            if (line != "")
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

        private List<string> GetUrlListFromSQL()
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
                            list.Add(reader["URL"].ToString().Trim());
                        }
                        reader.Close();
                        conn.Close();
                    }
                }
                catch (Exception e)
                {
                    nlog.SaveException(e);
                }
            }
            return list;
        }

        public bool TestSQL(string sqlConn = "")
        {
            if (sqlConn == "") sqlConn = SQLConnString;
            bool isOK = false;
            if (!string.IsNullOrEmpty(sqlConn))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(sqlConn + ";Connection Timeout=2"))
                    {                        
                        conn.Open();
                        isOK = true;
                    }
                }
                catch (Exception e)
                {
                    nlog.SaveException(e);
                    isOK = false;
                }
            }
            return isOK;
        }
    }
}
