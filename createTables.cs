using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace TripsApp
{
    public class Create_Tables
    {


        public void createTables()
        {
            SqlConnection ServerConnection1 = new SqlConnection(ServerConstructor.ServerConnectionString1);

            try
            {
                ServerConnection1.Open();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            SqlCommand tblcreatecommand = new SqlCommand();
            tblcreatecommand.Connection = ServerConnection1;
            tblcreatecommand.CommandType = CommandType.Text;
            tblcreatecommand.CommandText = ServerConstructor.tblecreationString;

            int Createtbl = tblcreatecommand.ExecuteNonQuery();

            SqlCommand tbl1createcommand = new SqlCommand();
            tbl1createcommand.Connection = ServerConnection1;
            tbl1createcommand.CommandType = CommandType.Text;
            tbl1createcommand.CommandText = ServerConstructor.tble1creationString;

            int Createtbl1 = tbl1createcommand.ExecuteNonQuery();

            SqlCommand tbl2createcommand = new SqlCommand();
            tbl2createcommand.Connection = ServerConnection1;
            tbl2createcommand.CommandType = CommandType.Text;
            tbl2createcommand.CommandText = ServerConstructor.tble2creationString;

            int Createtbl2 = tbl2createcommand.ExecuteNonQuery();

            SqlCommand tbl3createcommand = new SqlCommand();
            tbl3createcommand.Connection = ServerConnection1;
            tbl3createcommand.CommandType = CommandType.Text;
            tbl3createcommand.CommandText = ServerConstructor.tble3creationString;

            int Createtbl3 = tbl3createcommand.ExecuteNonQuery();

            ServerConnection1.Close();
        }
    }
}
