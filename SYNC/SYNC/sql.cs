using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SYNC
{
    class sql
    {
        public static string GetAttribs(long myAccount, string SqlConn)
        {
            string attribs = "";
            using (SqlConnection conn = new SqlConnection(SqlConn))
            {
                SqlCommand command = new SqlCommand("[ToTangoDataExport]", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@MaxRows", SqlDbType.Int);
                command.Parameters["@MaxRows"].Value = 100;
                command.Parameters.Add("@AccountID", SqlDbType.BigInt);
                command.Parameters["@AccountID"].Value = myAccount;
                conn.Open();

                string key, value;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    attribs = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        key = HttpUtility.UrlEncode(reader.GetName(i));
                        if (key != "ID")
                        {
                            value = HttpUtility.UrlEncode(reader[i].ToString());
                            attribs += "&sdr_o." + key + "=" + value;
                        }
                    }
                }
                reader.Close();
                conn.Close();
                return attribs;
            }
        }

        public static string GetName(long myAccount, string SqlConn)
        {
            string Name = "";
            using (SqlConnection conn = new SqlConnection(SqlConn))
            {
                SqlCommand command = new SqlCommand("SELECT Name FROM tblCompany WITH (NOLOCK) " +                                
                                "WHERE COMPID = " + myAccount.ToString(), conn);
                command.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Name = HttpUtility.UrlEncode(reader["Name"].ToString());
                }
                reader.Close();
                conn.Close();
            }
            return Name;
        }


    }
}
