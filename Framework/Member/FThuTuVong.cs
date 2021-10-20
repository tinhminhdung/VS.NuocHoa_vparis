using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FThuTuVong
    {

        #region Name Text
        public List<EEThuTuVong> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<EEThuTuVong>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
