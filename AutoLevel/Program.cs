using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AutoLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("shopDb");
            DataTable usersTable = new DataTable("users");
            dataSet.Tables.Add(usersTable);

            usersTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn
                {
                    ColumnName = "id",
                    AllowDBNull = false,
                    AutoIncrement = true,
                    AutoIncrementSeed = 1,
                    AutoIncrementStep = 1,
                    Unique = true,
                    DataType = typeof(int),
                },
                new DataColumn
                {
                    ColumnName = "login",
                    Unique = true,
                    DataType = typeof(string),
                },
                new DataColumn
                {
                    ColumnName = "password",
                    
                    DataType = typeof(string),
                }
            });

            DataRow firstRow = usersTable.NewRow();

            firstRow.BeginEdit();
            firstRow.ItemArray = new object[] { 1, "admin", "12345" };
            firstRow.EndEdit();

            usersTable.Rows.Add();

        }
    }
}
