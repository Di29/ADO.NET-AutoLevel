using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("shopDb");
            //DataTable usersTable = new DataTable("users");
            //dataSet.Tables.Add(usersTable);

            //usersTable.Columns.AddRange(new DataColumn[]
            //{
            //    new DataColumn
            //    {
            //        ColumnName = "id",
            //        AllowDBNull = false,
            //        AutoIncrement = true,
            //        AutoIncrementSeed = 1,
            //        AutoIncrementStep = 1,
            //        Unique = true,
            //        DataType = typeof(int),
            //    },
            //    new DataColumn
            //    {
            //        ColumnName = "login",
            //        Unique = true,
            //        DataType = typeof(string),
            //    },
            //    new DataColumn
            //    {
            //        ColumnName = "password",
                    
            //        DataType = typeof(string),
            //    }
            //});

            //DataRow firstRow = usersTable.NewRow();

            //firstRow.BeginEdit();
            //firstRow.ItemArray = new object[] { 4, "admin", "12345" };
            //firstRow.EndEdit();

            //usersTable.Rows.Add();

            DataRelation dataRelation = new DataRelation("user_person_relation", "people", "users", new string[] { "id"}, new string[] {"userid" }, false);

            SqlDataAdapter adapter = new SqlDataAdapter(
                "select * from users", 
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\УринбасаровД\source\repos\AutoLevel\AutoLevel\ProgramDataBase.mdf;Integrated Security=True");
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(dataSet);

            DataRow firstRow1 = dataSet.Tables[0].NewRow();

            firstRow1.BeginEdit();
            firstRow1.ItemArray = new object[] { 4, "admin", "12345" };
            firstRow1.EndEdit();

            dataSet.Tables[0].Rows.Add(firstRow1);
            adapter.Update(dataSet);
            
        }
    }
}
