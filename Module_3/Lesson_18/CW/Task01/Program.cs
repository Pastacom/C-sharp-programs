using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Task01
{
    class Program
    {
        private static DataTable ExecuteSQL_DataTable(string connectionString, string SQL, params Tuple<string, string>[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                using (SqliteCommand cmd = new SqliteCommand(SQL, con))
                {
                    cmd.CommandType = CommandType.Text;
                    foreach (var tuple in parameters)
                        cmd.Parameters.Add(new SqliteParameter(tuple.Item1, tuple.Item2));
                    con.Open();
                    SqliteDataReader reader = cmd.ExecuteReader();
                    for (int i = 0; i < reader.FieldCount; i++)
                        dt.Columns.Add(new DataColumn(reader.GetName(i)));



                    int rowIndex = 0;
                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();
                        dt.Rows.Add(row);
                        for (int i = 0; i < reader.FieldCount; i++)
                            dt.Rows[rowIndex][i] = (reader.GetValue(i));
                        rowIndex++;
                    }
                }
            }
            return dt;
        }

        static void Print(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                foreach (var t in row.ItemArray)
                    Console.Write(t + " ");
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string connectionString = "Data Source=AdventureWorksLT.db";
            string SQL1 = "UPDATE Product SET StandardCost = 50 WHERE ProductID = 680";
            string SQL2 = "UPDATE Product SET ListPrice = 78 WHERE ProductID = 680";
            ExecuteSQL_DataTable(connectionString, SQL1);
            ExecuteSQL_DataTable(connectionString, SQL2);

            string SQL3 = "DELETE FROM Product WHERE ProductID = 1";
            ExecuteSQL_DataTable(connectionString, SQL3);

            string SQL4 = "INSERT INTO Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate, rowguid)" +
            " VALUES (1, 'MyProduct', 'ABCD-XYZ', 'Cyan', 23, 73, '2002-06-01 00:00:00', '0')";
            ExecuteSQL_DataTable(connectionString, SQL4);


            string SQL5 = "DELETE FROM Product WHERE ProductID = 706";
            ExecuteSQL_DataTable(connectionString, SQL5);


            string SQL6 = "SELECT * FROM Product WHERE ListPrice < 700 and ListPrice > 560";
            var dt = ExecuteSQL_DataTable(connectionString, SQL6);
            Print(dt);

            Console.WriteLine("\n\n\n\n\n");
            string SQL7 = "SELECT * FROM Product WHERE INSTR(Name, 'Product') > 0";
            dt = ExecuteSQL_DataTable(connectionString, SQL7);
            Print(dt);

            Console.WriteLine("\n\n\n\n\n");
            string SQL8 = "SELECT * FROM Product WHERE ProductID = 1";
            dt = ExecuteSQL_DataTable(connectionString, SQL8);
            Print(dt);
        }
    }
}