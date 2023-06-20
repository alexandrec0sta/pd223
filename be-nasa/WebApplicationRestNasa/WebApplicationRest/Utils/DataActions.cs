using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplicationRest.Models;

namespace WebApplicationRest.Utils
{
    public class DataActions
    {
        public static string ReadDataSetthroughReader(string query)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;
            SqlDataReader reader;
            DataTable dataTable = new DataTable();

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                command = new SqlCommand();

                if (connection.State == ConnectionState.Closed)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.ConnectionString = connString;
                        connection.Open();
                    }

                }

                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;


                reader = command.ExecuteReader();
                dataTable.Load(reader);

                string result = JsonConvert.SerializeObject(dataTable);
                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteRow(int id, string query)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                command = new SqlCommand();

                if (connection.State == ConnectionState.Closed)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.ConnectionString = connString;
                        connection.Open();
                    }

                }

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.CommandType = CommandType.Text;

                int result = sqlCommand.ExecuteNonQuery();

                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object InsertRowAPOD(APOD objectAPOD)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                command = new SqlCommand();

                if (connection.State == ConnectionState.Closed)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.ConnectionString = connString;
                        connection.Open();
                    }

                }

                var query = $"INSERT INTO APOD(date,explanation,hdurl,media_type,service_version,title,url) VALUES(@date,@explanation,@hdurl,@media_type,@service_version,@title,@url);SELECT CAST(scope_identity() AS int)";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.CommandType = CommandType.Text;
                SqlParameter outPutVal = new SqlParameter("@Id", SqlDbType.Int);
                outPutVal.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(outPutVal);
                sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = objectAPOD.date;
                sqlCommand.Parameters.Add("@explanation", SqlDbType.NVarChar).Value = objectAPOD.explanation;
                sqlCommand.Parameters.Add("@hdurl", SqlDbType.NVarChar).Value = objectAPOD.hdurl;
                sqlCommand.Parameters.Add("@media_type", SqlDbType.NVarChar).Value = objectAPOD.media_type;
                sqlCommand.Parameters.Add("@service_version", SqlDbType.NVarChar).Value = objectAPOD.service_version;
                sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar).Value = objectAPOD.title;
                sqlCommand.Parameters.Add("@url", SqlDbType.NVarChar).Value = objectAPOD.url;

                var result = sqlCommand.ExecuteScalar();

                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateRowAPOD(int id, APOD objectAPOD)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                command = new SqlCommand();

                if (connection.State == ConnectionState.Closed)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.ConnectionString = connString;
                        connection.Open();
                    }

                }

                var query = $"UPDATE APOD SET date = @date , explanation = @explanation , hdurl = @hdurl, media_type =@media_type , service_version = @service_version, title = @title, url = @url  WHERE id ={id}";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = objectAPOD.date;
                sqlCommand.Parameters.Add("@explanation", SqlDbType.NVarChar).Value = objectAPOD.explanation;
                sqlCommand.Parameters.Add("@hdurl", SqlDbType.NVarChar).Value = objectAPOD.hdurl;
                sqlCommand.Parameters.Add("@media_type", SqlDbType.NVarChar).Value = objectAPOD.media_type;
                sqlCommand.Parameters.Add("@service_version", SqlDbType.NVarChar).Value = objectAPOD.service_version;
                sqlCommand.Parameters.Add("@title", SqlDbType.NVarChar).Value = objectAPOD.title;
                sqlCommand.Parameters.Add("@url", SqlDbType.NVarChar).Value = objectAPOD.url;

                int result = sqlCommand.ExecuteNonQuery();

                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object InsertRowTLE(TLE objectTLE)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                command = new SqlCommand();

                if (connection.State == ConnectionState.Closed)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.ConnectionString = connString;
                        connection.Open();
                    }

                }

                var query = $"INSERT INTO TLE(id,type,satelliteId,name,date,line1,line2) VALUES(@id,@type,@satelliteId,@name,@date,@line1,@line2)";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = objectTLE.id;
                sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar).Value = objectTLE.type;
                sqlCommand.Parameters.Add("@satelliteId", SqlDbType.Int).Value = objectTLE.satelliteId;
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = objectTLE.name;
                sqlCommand.Parameters.Add("@date", SqlDbType.Date).Value = objectTLE.date;
                sqlCommand.Parameters.Add("@line1", SqlDbType.NVarChar).Value = objectTLE.line1;
                sqlCommand.Parameters.Add("@line2", SqlDbType.NVarChar).Value = objectTLE.line2;

                var result = sqlCommand.ExecuteNonQuery();

                if (result == 1)
                {
                    result = objectTLE.satelliteId;
                }

                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateRowTLE(int id, TLE objectTLE)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                command = new SqlCommand();

                if (connection.State == ConnectionState.Closed)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.ConnectionString = connString;
                        connection.Open();
                    }

                }

                var query = $"UPDATE TLE SET id = @id , type = @type , name = @name, date =@date , line1 = @line1, line2 = @line2 WHERE satelliteId ={id}";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = objectTLE.id;
                sqlCommand.Parameters.Add("@type", SqlDbType.NVarChar).Value = objectTLE.type;
                sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = objectTLE.name;
                sqlCommand.Parameters.Add("@date", SqlDbType.Date).Value = objectTLE.date;
                sqlCommand.Parameters.Add("@line1", SqlDbType.NVarChar).Value = objectTLE.line1;
                sqlCommand.Parameters.Add("@line2", SqlDbType.NVarChar).Value = objectTLE.line2;

                int result = sqlCommand.ExecuteNonQuery();

                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateRowROVERS(int id, ROVERS objectROVERS)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command;

            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                command = new SqlCommand();

                if (connection.State == ConnectionState.Closed)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.ConnectionString = connString;
                        connection.Open();
                    }

                }

                var query = $"UPDATE ROVERS SET sol = @sol , camera_id = @camera_id , camera_name = @camera_name, camerarover_id = @camerarover_id , camerafull_name = @camerafull_name, img_src = @img_src, earth_date = @earth_date,  rover_id = @rover_id, rover_name = @rover_name, rover_landing_date = @rover_landing_date, rover_launch_date = @rover_launch_date, rover_status = @rover_status WHERE id ={id}";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add("@sol", SqlDbType.Int).Value = objectROVERS.sol;
                sqlCommand.Parameters.Add("@camera_id", SqlDbType.Int).Value = objectROVERS.camera_id;
                sqlCommand.Parameters.Add("@camera_name", SqlDbType.NVarChar).Value = objectROVERS.camera_name;
                sqlCommand.Parameters.Add("@camerarover_id", SqlDbType.Int).Value = objectROVERS.camerarover_id;
                sqlCommand.Parameters.Add("@camerafull_name", SqlDbType.NVarChar).Value = objectROVERS.camerafull_name;
                sqlCommand.Parameters.Add("@img_src", SqlDbType.NVarChar).Value = objectROVERS.img_src;
                sqlCommand.Parameters.Add("@earth_date", SqlDbType.Date).Value = objectROVERS.earth_date;
                sqlCommand.Parameters.Add("@rover_id", SqlDbType.Int).Value = objectROVERS.rover_id;
                sqlCommand.Parameters.Add("@rover_name", SqlDbType.NVarChar).Value = objectROVERS.rover_name;
                sqlCommand.Parameters.Add("@rover_landing_date", SqlDbType.Date).Value = objectROVERS.rover_landing_date;
                sqlCommand.Parameters.Add("@rover_launch_date", SqlDbType.Date).Value = objectROVERS.rover_launch_date;
                sqlCommand.Parameters.Add("@rover_status", SqlDbType.NVarChar).Value = objectROVERS.rover_status;


                int result = sqlCommand.ExecuteNonQuery();

                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    
}