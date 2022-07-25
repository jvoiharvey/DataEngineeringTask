using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace TripsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase constructDB = new CreateDatabase();
            constructDB.createDatabase();


            Create_Tables constructTables = new Create_Tables();
            constructTables.createTables();

            extractData getData = new extractData();
            getData.getExcelData();

            cleanData clean_data = new cleanData();
            clean_data.cleanTripsData();
        }
    }
}
