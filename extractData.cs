using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace TripsApp
{
    public class extractData
    {
        public extractData()
        {
        }


        public void getExcelData()
        {
            Application tripsExcel = new Application();
            if (tripsExcel == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

            Workbook excelBook = tripsExcel.Workbooks.Open(excelConstructor.excelConnection );
            _Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;
            

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;

            

            SqlConnection ServerConnection = new SqlConnection(ServerConstructor.ServerConnectionString1);

            try
            {
                ServerConnection.Open();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            if (rows > 0)
            {
                SqlCommand deletecommand = new SqlCommand();
                deletecommand.Connection = ServerConnection;            // <== lacking
                deletecommand.CommandType = CommandType.Text;
                deletecommand.CommandText = ServerConstructor.deleteTbleString;
                int Deleterecords = deletecommand.ExecuteNonQuery();

                string region = "Unknown";
                string origin = "Unknown";
                string destination = "Unknown";
                string date_time = Convert.ToString("9/9/9999 12:00");
                string datasource = "Unknown";


                for (int x = 2; x <= rows; x++)
                {
                    //create new line
                    Console.Write("\r\n");




                    SqlCommand command = new SqlCommand();
                    command.Connection = ServerConnection;            // <== lacking
                    command.CommandType = CommandType.Text;

                    command.CommandText = ServerConstructor.insertTbleString;

                    try
                    {
                        if (excelRange.Cells[x, 1] != null && excelRange.Cells[x, 1].Value2 != null)
                            region = excelRange.Cells[x, 1].Value2.ToString();

                        Console.Write(region);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    try
                    {
                        if (excelRange.Cells[x, 2] != null && excelRange.Cells[x, 2].Value2 != null)
                            origin = excelRange.Cells[x, 2].Value2.ToString();

                        Console.Write(origin);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    try
                    {
                        if (excelRange.Cells[x, 3] != null && excelRange.Cells[x, 3].Value2 != null)
                            destination = excelRange.Cells[x, 3].Value2.ToString();

                        Console.Write(destination);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    try
                    {
                        if (excelRange.Cells[x, 4] != null && excelRange.Cells[x, 4].Value2 != null)

                            date_time = excelRange.Cells[x, 4].Value.ToString();

                        Console.Write(date_time);
                        //Console.Write(date_time);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    try
                    {
                        if (excelRange.Cells[x, 5] != null && excelRange.Cells[x, 5].Value2 != null)
                            datasource = excelRange.Cells[x, 5].Value2.ToString();

                        Console.Write(datasource);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    command.Parameters.AddWithValue("@REGION", region);
                    command.Parameters.AddWithValue("@ORIGIN", origin);
                    command.Parameters.AddWithValue("@DESTINATION", destination);
                    command.Parameters.AddWithValue("@DATE_TIME", date_time);
                    command.Parameters.AddWithValue("@DATASOURCE", datasource);




                    try
                    {

                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException E)
                    {

                        Console.Write(E.Message);

                    }

                }
                //after reading, relaase the excel project
                Console.ReadLine();
                tripsExcel.Quit();
                tripsExcel.Workbooks.Close();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(tripsExcel);
                


                ServerConnection.Close();

                

            }
           
        }

    }
}

