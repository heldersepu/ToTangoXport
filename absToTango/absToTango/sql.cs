using System;
using System.Data;
using System.Data.SqlClient;


namespace absToTango
{
    class sql
    {

        private string _sqlConn = "";

        /// <summary>
        /// Initializes a new instance of the sql class
        /// </summary>
        /// <param name="sqlConString">SQL connection string</param>
        public sql(string sqlConString)
        {
            this._sqlConn = sqlConString;
        }

        public string AddCall(string name, string url)
        {
            string id = "0";
            if (!string.IsNullOrEmpty(_sqlConn))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_sqlConn))
                    {
                        SqlCommand command = new SqlCommand("[event].[InsertCampaign]", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Name", SqlDbType.Text);
                        command.Parameters["@Name"].Value = name;
                        command.Parameters.Add("@URL", SqlDbType.Text);
                        command.Parameters["@URL"].Value = url;
                        conn.Open();

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            id = reader["id"].ToString();
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
            return id;
        }

        public void AddAttrib(string id, string Account, string key, string value)
        {
            if (!string.IsNullOrEmpty(_sqlConn) && (id != "0"))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_sqlConn))
                    {
                        SqlCommand command = new SqlCommand("[event].[InsertCampaignAttribute]", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@ID", SqlDbType.Text);
                        command.Parameters["@ID"].Value = id;
                        command.Parameters.Add("@Account", SqlDbType.Text);
                        command.Parameters["@Account"].Value = Account;                    
                        command.Parameters.Add("@Key", SqlDbType.Text);
                        command.Parameters["@Key"].Value = key;
                        command.Parameters.Add("@Value", SqlDbType.Text);
                        command.Parameters["@Value"].Value = value;
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                catch (Exception e)
                {
                    nlog.SaveException(e);
                }
            }
        }
    }
}   
