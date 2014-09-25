using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace absToTango
{
    /// <summary>
    /// Provides an easy way to export ToTango filters 
    /// </summary>
    public class ToTangoExport
    {
        private string _token;
        private string _headers = "";
        private string _aliasHead = "";
        private string[] _headArr;
        private sql _sqlLog;

        /// <summary>
        /// Initializes a new instance of the ToTangoExport class.
        /// </summary>
        /// <param name="token">Your ToTango API authentication key.</param>
        /// <param name="headerFile">Your Mapping file.</param>
        /// <param name="sqlConString">Optional SQL connection string</param>
        public ToTangoExport(string token, string headerFile, string sqlConString = "")
        {            
            this._token = token;
            this._sqlLog = new sql(sqlConString);
            foreach (string line in File.ReadAllLines(headerFile))
            {
                if ((line.Trim().Length > 0) && (!line.StartsWith("#")))
                {
                    if (this._headers == "")
                    {
                        this._headers = line.Replace("\t", "");
                        this._headArr = this._headers.Split(',');
                        this._aliasHead = this._headers;
                    }
                    else
                    {
                        this._aliasHead = line.Replace("\t", "");
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Start the export on the given url
        /// </summary>
        /// <param name="url">The Url to the API, something like: https://app.totango.com/api/v1/accounts/active_list/10010/current.json</param> 
        /// <param name="outDirectory">The directory for output file</param>
        /// <param name="outName">The name of the output file</param>        
        /// <param name="confUrl">Optional confirmation base url</param>
        public string Start(string url, string outDirectory, string outName, string confUrl = "")
        {
            string name = "";            
            List<string> lines = new List<string>();
            lines.Add(this._aliasHead);
            if (this._headers.Length > 0)
            {
                using (ToTangoReader tangoReader = new ToTangoReader(this._token, url))
                {
                    name = tangoReader.ReadName();
                    string id = this._sqlLog.AddCall(name, url);
                    dynamic account = null;
                    do
                    {
                        account = tangoReader.ReadAccount();                        
                        if (account != null)
                        {                            
                            lines.Add(concatAttribs(id, account));
                            if (!String.IsNullOrEmpty(confUrl))
                                sendConfirmation(account, confUrl);
                        }
                    }
                    while (account != null);                    
                }
            }
            string ext = Path.GetExtension(outName);
            if (name != "") outName = cleanName(name) + ext;
            outName = newName(outDirectory + "\\" + outName, ext);
            File.WriteAllLines(outName, lines);
            return outName;
        }

#region "  Private Methods  "

        private string cleanName(string name)
        {
            name = name.Replace('/', '_');
            name = name.Replace('\\', '_');
            name = name.Replace(':', '_');
            name = name.Replace('*', '_');
            name = name.Replace('?', '_');
            name = name.Replace('"', '_');
            name = name.Replace('>', '_');
            name = name.Replace('<', '_');
            name = name.Replace('|', '_');
            return name;
        }
        
        private string newName(string outname, string ext)
        {
            string dName = outname.Replace(ext, "");
            int i = 0;
            while (File.Exists(outname))
            {                
                outname = dName + i.ToString() + ext;
                i++;
            }
            return outname;
        }
        
        private string concatAttribs(string id, dynamic account)
        {
            string line = "";
            string accID = getAttrib(account, "account_id");
            foreach (string attrib in this._headArr)
            {
                string aValue = getAttrib(account, attrib);
                this._sqlLog.AddAttrib(id, accID, attrib, aValue);
                line += "\"" + aValue + "\",";
            }
            return line.TrimEnd(',');
        }

        private string getAttrib(dynamic account, string attrib, string defValue = "")
        {
            string ret = defValue;
            attrib = attrib.Replace('"',' ').Trim();
            if (account.attributes[attrib] != null)
            {
                ret = account.attributes[attrib].value;
            }
            else if ((attrib == "name") || (attrib == "account_id"))
            {
                ret = account[attrib].Value;
            }             
            return ret;
        }

        private void sendConfirmation(dynamic account, string confUrl)
        {
            string account_id = account.account_id.Value;
            int campaign = 0;
            try
            {
                campaign = Convert.ToInt32(getAttrib(account, "campaign", "0"));
            }
            catch (Exception e)
            {
                nlog.SaveException(e);
            }
            campaign++;

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add("Authorization", this._token);
                    client.DownloadString(confUrl + account_id + "&sdr_o.Campaign=" + campaign);
                }
                catch (Exception e)
                {
                    nlog.SaveException(e);   
                }
            }
        }

#endregion
    }
}
