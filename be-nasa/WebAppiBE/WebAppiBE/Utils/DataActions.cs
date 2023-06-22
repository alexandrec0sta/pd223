using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebAppiBE.Models;

namespace WebAppiBE.Utils
{
    public class DataActions
    {
        private static string connString = "Host=localhost;Port=5432;Database=PGDB;Username=admin;Password=12345;";
        public static DataTable ReadDataSetthroughReader(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connString))
                {
                    connection.Open();

                    // Create a new NpgsqlDataAdapter and fill the DataTable
                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(query, connection))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }

                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteRow(string query)
        {
            try
            {
                int result;

                using (NpgsqlConnection connection = new NpgsqlConnection(connString))
                {
                    connection.Open();

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        result = command.ExecuteNonQuery();
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateRowTLE(int id, TLE objectTLE)
        {
            try
            {
                int result; 

                using (NpgsqlConnection connection = new NpgsqlConnection(connString))
                {
                    connection.Open();

                    var query = $"UPDATE tle SET id = @id , type = @type , name = @name, date =@date , line1 = @line1, line2 = @line2 WHERE satelliteId ={id}";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", objectTLE.id);
                        command.Parameters.AddWithValue("@type", objectTLE.type);
                        command.Parameters.AddWithValue("@name", objectTLE.name);
                        command.Parameters.AddWithValue("@date", objectTLE.date);
                        command.Parameters.AddWithValue("@line1", objectTLE.line1);
                        command.Parameters.AddWithValue("@line2", objectTLE.line2);


                        result =command.ExecuteNonQuery();
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Dictionary<string, object>> DataTableToJson(DataTable dataTable)
        {
            return dataTable.Rows.Cast<DataRow>()
                .Select(row => dataTable.Columns.Cast<DataColumn>()
                    .ToDictionary(column => column.ColumnName, column => row[column]))
                .ToList();
        }
    }
}
