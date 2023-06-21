using Newtonsoft.Json;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using WebCrawler.Models;
using static WebCrawler.Models.TLE;

namespace WebCrawler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Host=172.17.0.2;Port=5432;Database=PGDB;Username=admin;Password=12345;";

            using (HttpClient client = new HttpClient())
            {
                string tleApiUrl = "https://tle.ivanstanojevic.me/api/tle/";
                string tleApiResponse = await client.GetStringAsync(tleApiUrl);

                string apodApiUrl = "https://api.nasa.gov/planetary/apod?api_key=fISn85mhKQfmVWrwOrULvlWLnafz2SGkhpX0HisX";
                string apodApiResponse = await client.GetStringAsync(apodApiUrl);


                TLEData tleDataList = JsonConvert.DeserializeObject<TLEData>(tleApiResponse);

                APOD apodData = JsonConvert.DeserializeObject<APOD>(apodApiResponse);

                foreach (Member item in tleDataList.member)
                {
                    if (!CheckIfTLEExists(item.satelliteId, connectionString))
                    {
                        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                        {
                            connection.Open();

                            string insertQuery = "INSERT INTO tle (id,type,satelliteId,name,date,line1,line2) VALUES(@id,@type,@satelliteId,@name,@date,@line1,@line2)";

                            using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@id", item.id);
                                command.Parameters.AddWithValue("@type", item.type);
                                command.Parameters.AddWithValue("@satelliteId", item.satelliteId);
                                command.Parameters.AddWithValue("@name", item.name);
                                command.Parameters.AddWithValue("@date", item.date);
                                command.Parameters.AddWithValue("@line1", item.line1);
                                command.Parameters.AddWithValue("@line2", item.line2);

                                command.ExecuteNonQuery();

                                connection.Close();
                            }
                        }
                    }
                }

                if (apodData != null)
                {
                    if (!CheckIfAPODExists(apodData.url, connectionString))
                    {
                        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                        {
                            connection.Open();

                            string insertQuery = "INSERT INTO apod (date, explanation, hdurl, media_type, service_version, title, url) VALUES (@date, @explanation, @hdurl, @media_type, @service_version, @title, @url)";

                            using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection))
                            {
                                command.Parameters.AddWithValue("@date", apodData.date);
                                command.Parameters.AddWithValue("@explanation", apodData.explanation);
                                command.Parameters.AddWithValue("@hdurl", apodData.hdurl);
                                command.Parameters.AddWithValue("@media_type", apodData.media_type);
                                command.Parameters.AddWithValue("@service_version", apodData.service_version);
                                command.Parameters.AddWithValue("@title", apodData.title);
                                command.Parameters.AddWithValue("@url", apodData.url);

                                command.ExecuteNonQuery();

                                connection.Close();
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Dados inseridos na BD");
            Console.ReadLine();
        }

        public static bool CheckIfTLEExists(int satelliteId, string connectionString)
        {
            bool exists = false;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(*) FROM tle WHERE SatelliteId = @SatelliteId";
                    command.Parameters.AddWithValue("@SatelliteId", satelliteId);

                    var count1 = command.ExecuteScalar();

                    int count = Convert.ToInt32(count1);

                    if (count > 0)
                    {
                        exists = true;
                    }
                }

                return exists;
            }
        }
        public static bool CheckIfAPODExists(string url, string connectionString)
        {
            bool exists = false;

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(*) FROM apod WHERE url = @url";
                    command.Parameters.AddWithValue("@url", url);

                    var count1 = command.ExecuteScalar();

                    int count = Convert.ToInt32(count1);

                    if (count > 0)
                    {
                        exists = true;
                    }
                }

                return exists;
            }
        }
    }
}
