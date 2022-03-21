using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Task01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly string connectionString = "Data Source=AdventureWorksLT.db";
        private int Counter = 0;
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

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            string SQL = "SELECT * FROM Product";
            var dt = ExecuteSQL_DataTable(connectionString, SQL);
            return Ok(JsonConvert.SerializeObject(dt));
        }

        [HttpGet("GetProductByID")]
        public IActionResult GetProductByID([Required] int id)
        {
            string SQL = $"SELECT * FROM Product WHERE ProductID = {id}";
            var dt = ExecuteSQL_DataTable(connectionString, SQL);
            if(JsonConvert.SerializeObject(dt).Length == 2)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(dt));
        }

        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct([Required] int id, [Required] string name, [Required] string number, [Required] string color, [Required] int cost, [Required] int price)
        {
            string SQL = $"UPDATE Product SET Name = '{name}', ProductNumber = '{number}'," +
            $" Color = '{color}', StandardCost = {cost}, ListPrice = {price} WHERE ProductID = {id}";
            ExecuteSQL_DataTable(connectionString, SQL);
            return Ok();
        }

        [HttpPost("AddProduct")]
        public IActionResult InsertNewProduct([Required] string name, [Required] string number, [Required] string color, [Required] int cost, [Required] int price)
        {
            string SQL = $"INSERT INTO Product (ProductID, Name, ProductNumber, Color, StandardCost, ListPrice, SellStartDate, rowguid)" +
            $" VALUES ({GetID(ref Counter)}, '{name}', '{number}', '{color}', {cost}, {price}, '2002-06-01 00:00:00', '{Counter}')";
            ExecuteSQL_DataTable(connectionString, SQL);
            return Ok(Counter);
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct([Required] int id)
        {
            string SQL = $"DELETE FROM Product WHERE ProductID = {id}";
            ExecuteSQL_DataTable(connectionString, SQL);
            return Ok();
        }
        private int GetID(ref int id)
        {
            IDIsOccupied:
                if (GetProductByID(id) is NotFoundResult)
                {
                    return id; 
                }
                else
                {
                    id++;
                    goto IDIsOccupied;
                }
        }
    }
}
