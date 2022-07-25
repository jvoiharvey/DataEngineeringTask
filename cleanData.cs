using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TripsApp
{
    public class cleanData
    {
        public cleanData()
        {

        }
        public void cleanTripsData()
        {
            SqlConnection ServerConnection = new SqlConnection(ServerConstructor.ServerConnectionString1);

            try
            {
                ServerConnection.Open();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            SqlCommand deletecommand = new SqlCommand();
            deletecommand.Connection = ServerConnection;            // <== lacking
            deletecommand.CommandType = CommandType.Text;
            deletecommand.CommandText = ServerConstructor.deleteTble1String;
            int Deleterecords = deletecommand.ExecuteNonQuery();


            SqlCommand command = new SqlCommand();
            command.Connection = ServerConnection;            // <== lacking
            command.CommandType = CommandType.Text;

            command.CommandText = ServerConstructor.insertTble1String;
            int insertRecords = command.ExecuteNonQuery();


            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = ServerConnection;            // <== lacking
            updateCommand.CommandType = CommandType.Text;

            updateCommand.CommandText = ServerConstructor.updateTble1String;
            int updateRecords = updateCommand.ExecuteNonQuery();


            SqlCommand delete1command = new SqlCommand();
                delete1command.Connection = ServerConnection;            // <== lacking
                delete1command.CommandType = CommandType.Text;
                delete1command.CommandText = ServerConstructor.deleteTble2String;
                int Deleterecords1 = delete1command.ExecuteNonQuery();

            
            SqlCommand command1 = new SqlCommand();
            command1.Connection = ServerConnection;            // <== lacking
            command1.CommandType = CommandType.Text;

            command1.CommandText = ServerConstructor.insertTble2String;
            int insertRecords1 = command1.ExecuteNonQuery();

            SqlCommand delete2command = new SqlCommand();
            delete2command.Connection = ServerConnection;            // <== lacking
            delete2command.CommandType = CommandType.Text;
            delete2command.CommandText = ServerConstructor.deleteTble3String;
            int Deleterecords2 = delete2command.ExecuteNonQuery();


            SqlCommand insert3Command = new SqlCommand();
            insert3Command.Connection = ServerConnection;            // <== lacking
            insert3Command.CommandType = CommandType.Text;

            insert3Command.CommandText = ServerConstructor.insertTble3String;
            int insert3Records = insert3Command.ExecuteNonQuery();

        }
    }
}
