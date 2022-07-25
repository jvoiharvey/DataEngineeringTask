using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TripsApp
{
    public class ServerConstructor
    {
        //insert credentials where insert comment is

           public const string userID = "";//insert
           public const string pWord = "";//insert
           public const string server = ""; //insert
        public const string ServerConnectionString = "user id= " + userID + ";" +
                                  "password= " + pWord + ";"  +
                                  "server= " + server + ";" +
                                  "Trusted_Connection=yes;" +
                                  "connection timeout=30";


        public const string databaseName = "JevoiDB";
        public const string tbleName = "trips";
        public const string tbleName1 = "trips2";

        public const string tbleName2 = "tripsCleaned";
        public const string tbleName3 = "lastExtractTable";



        public const string dbcreationString = "IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'" + databaseName +
                "')BEGIN DROP DATABASE " + databaseName + "; END;" +
                "CREATE DATABASE " + databaseName + ";";

        public const string ServerConnectionString1 = "user id= " + userID + ";" +
                                  "password= " + pWord + ";" +
                                  "server= " + server + ";" +
                                  "Trusted_Connection=yes;" +
                                 "database=  " + databaseName + ";" +
                                 "connection timeout=30";

        public const string tblecreationString = "IF EXISTS (SELECT * FROM " + databaseName +".sys.tables WHERE name = N'" + tbleName+ "') BEGIN DROP TABLE " +
            databaseName + ".[dbo]." + tbleName + "; END;" +
            "CREATE TABLE " + tbleName + "(" +
                "Region nvarchar(255)," +
                "Origin nvarchar(max), " +
                "Destination nvarchar(max)," +
                "Date_Time nvarchar(50)," +
                "DataSource nvarchar(255));";

        public const string tble1creationString = "IF EXISTS (SELECT * FROM " + databaseName + ".sys.tables WHERE name = N'" + tbleName1 + "') BEGIN DROP TABLE " +
            databaseName + ".[dbo]." + tbleName1 + "; END;" +
            "CREATE TABLE " + tbleName1 + "(" +
                "Region nvarchar(255)," +
                "Origin nvarchar(max), " +
                "Destination nvarchar(max)," +
                "Date_Time nvarchar(50)," +
                "Date_Time2 DateTime," +
                "week_num int," +

                "[Month] int," +
                "[Day] int," +
                "[Other] nvarchar(255),"+
                "[DataSource] nvarchar(max));";


        public const string tble2creationString = "IF EXISTS (SELECT * FROM " + databaseName + ".sys.tables WHERE name = N'" + tbleName2 + "') BEGIN DROP TABLE " +
            databaseName + ".[dbo]." + tbleName2 + "; END;" +
            "CREATE TABLE " + tbleName2 + "(" +
                "Region nvarchar(255)," +
                "week_num int," +
                "num_of_trips int," +
                "weekly_average int);";

        public const string tble3creationString = "IF EXISTS (SELECT * FROM " + databaseName + ".sys.tables WHERE name = N'" + tbleName3 + "') BEGIN DROP TABLE " +
            databaseName + ".[dbo]." + tbleName3 + "; END;" +
            "CREATE TABLE " + tbleName3 + "(LastExtract datetime);";

        public const string deleteTbleString = "TRUNCATE TABLE [" + databaseName +"].[dbo].["+ tbleName + "]";

        public const string deleteTble1String = "TRUNCATE TABLE [" + databaseName + "].[dbo].[" + tbleName1 + "]";


        public const string deleteTble2String = "TRUNCATE TABLE [" + databaseName + "].[dbo].[" + tbleName2 + "]";

        public const string insertTbleString = "INSERT into [" + databaseName + "].[dbo].[" + tbleName + "]" +
            "([REGION],[ORIGIN],[DESTINATION],[DATE_TIME],[DATASOURCE]) VALUES (@REGION,@ORIGIN,@DESTINATION,@DATE_TIME,@DATASOURCE) ";

        public const string insertTble1String = "INSERT into [" + databaseName + "].[dbo].[" + tbleName1 + "]" +
            "([REGION],[ORIGIN],[DESTINATION],[DATE_TIME],[MONTH],[DAY],[OTHER],[DataSource]) SELECT [Region],[Origin],[Destination],[Date_Time]" +
      ",SUBSTRING([DATE_TIME],CHARINDEX('/', [DATE_TIME]) +1,charindex('/', [DATE_TIME], (charindex('/', [DATE_TIME])+1)) - CHARINDEX('/', [DATE_TIME]) - 1)" +
      ",SUBSTRING([DATE_TIME],1, CHARINDEX('/', [DATE_TIME]) - 1),SUBSTRING([DATE_TIME], charindex('/', [DATE_TIME], (charindex('/', [DATE_TIME])+1))+1,30),[DataSource]" +
            "FROM[" + databaseName + "].[dbo].[" + tbleName + "]";

        public const string updateTble1String = "UPDATE [" + databaseName + "].[dbo].[" + tbleName1 + "] SET [DATE_TIME2] = CONVERT(DATETIME,CONCAT([MONTH],'/',[DAY],'/',[OTHER]))" +
            ",[week_num] = DATEPART(WEEK,CONVERT(DATETIME,CONCAT([MONTH],'/',[DAY],'/',[OTHER])))";


        public const string insertTble2String = "INSERT into [" + databaseName + "].[dbo].[" + tbleName2 + "]" +
            "([REGION],[week_num],[num_of_trips],[weekly_average]) SELECT [REGION], [week_num],COUNT(*), (COUNT(*)/7) FROM [" + databaseName + "].[dbo].[" + tbleName1 + "]" +
            "GROUP BY [REGION],[week_num]";

        public const string deleteTble3String = "TRUNCATE TABLE [" + databaseName + "].[dbo].[" + tbleName3 + "]";

        public const string insertTble3String = "INSERT into [" + databaseName + "].[dbo].[" + tbleName3 + "]" +
            "([LastExtract])SELECT CURRENT_TIMESTAMP";






    }





}

