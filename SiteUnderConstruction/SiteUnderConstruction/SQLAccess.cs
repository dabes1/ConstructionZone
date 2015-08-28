using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// added usings
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SiteUnderConstruction
{
    public class SQLAccess
    {
        public static string GetDesc()
        {
            string _out = string.Empty;

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Connections.GetConnection;
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT DESCRIPTION FROM Table1 WHERE Id=1", con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;

                    try
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr != null && sdr.HasRows)
                            {
                                DataTable dt = new DataTable();
                                dt.Load(sdr);
                                _out = dt.Rows[0][0].ToString();
                                return _out;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        return e.Message.ToString();
                    }
                }
            }

            return _out;
        }
    }

    public class Connections
    {
        private static string _connectStr = ConfigurationManager.ConnectionStrings["DB1"].ConnectionString;
        //private static string _connectStr = "";
        public static string GetConnection {  get { return _connectStr; } }
    }
}