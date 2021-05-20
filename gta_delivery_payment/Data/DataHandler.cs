using System;
using gta_delivery_payment.Helpers;
using Oracle.ManagedDataAccess.Client;

namespace gta_delivery_payment.Data
{
    public class DataHandler
    {
        public OracleDataReader GetData(string query)
        {
            OracleConnection con = new OracleConnection(Constants.con);
            OracleCommand cmd = con.CreateCommand();
            try
            {
                con.Open();
                cmd.BindByName = true;
                cmd.CommandText = query;
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                return null;
            }
        }
    }
}
