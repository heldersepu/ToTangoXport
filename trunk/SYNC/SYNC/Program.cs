using System;
using System.Net;
using System.Configuration;
using Newtonsoft.Json;

namespace SYNC
{
    class Program
    {
        static string QueryUrl;
        static string SyncUrl;
        static string Token;
        static string SqlConn;

        static void Init()
        {
            QueryUrl = ConfigurationManager.AppSettings.Get("QueryUrl");
            SyncUrl = ConfigurationManager.AppSettings.Get("SyncUrl");
            Token = ConfigurationManager.AppSettings.Get("Token");
            SqlConn = ConfigurationManager.AppSettings.Get("SqlConn");
        }

        static void Main(string[] args)
        {
            Init();
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add("Authorization", Token);
                    string HtmlResult = client.UploadString(QueryUrl.Replace('\'', '"'), "");
                    ProcessResponse(HtmlResult);
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ProcessResponse(string json)
        {
            string attribs;
            long myAccount = 0;
            dynamic dJSON = JsonConvert.DeserializeObject(json);
            foreach (dynamic account in dJSON.response.accounts.hits)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(account.name);
                if (long.TryParse(account.name.ToString(), out myAccount))
                {
                    attribs = "&sdr_odn=" + sql.GetName(myAccount, SqlConn); 
                    attribs += sql.GetAttribs(myAccount, SqlConn);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" " + SyncAccount(myAccount, attribs));
                }
                Console.WriteLine("");
            }

        }

        private static string SyncAccount(long myAccount, string attribs)
        {
            string url = SyncUrl + myAccount.ToString() + attribs;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                return response.StatusCode.ToString();
            }
        }
        
    }
}
