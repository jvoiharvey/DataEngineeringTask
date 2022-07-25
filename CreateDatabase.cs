using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TripsApp
{
   public class CreateDatabase
    {
        public void createDatabase()
        {
            SqlConnection ServerConnection = new SqlConnection(ServerConstructor.ServerConnectionString);

            try
            {
                ServerConnection.Open();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            SqlCommand dbcreatecommand = new SqlCommand();
            dbcreatecommand.Connection = ServerConnection;
            dbcreatecommand.CommandType = CommandType.Text;
            dbcreatecommand.CommandText = ServerConstructor.dbcreationString;

            int CreateDB = dbcreatecommand.ExecuteNonQuery();

            ServerConnection.Close();

           
        }
    }
}

