using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;


namespace GetEmployeeCount
{
    public partial class StoredProcedures
    {
        [SqlProcedure]
        public static int GetEmployeeCount()
        {
            int iRows;
            SqlConnection connection = new SqlConnection("Context Connection=true");
            connection.Open();

            SqlCommand sqlCmd = connection.CreateCommand();
            sqlCmd.CommandText = "select count(*) as 'Employee Count'" + "from employee";
            iRows = (int)sqlCmd.ExecuteScalar();
            connection.Close();
            return iRows;
        }
    }
}
