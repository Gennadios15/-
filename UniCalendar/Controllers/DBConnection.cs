using MySql.Data.MySqlClient;

namespace ImportData
{
    public class DBConnection
    {
        public List<string> FetchData()
        {
            string serverIp = "unicalendar.mysql.database.azure.com";
            string username = "admin1";
            string password = "FEFEdeefa1732!";
            string databaseName = "unicalendar_db";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            string query = "SELECT * FROM modules";

            List<string> results = new List<string>();

            using (var conn = new MySqlConnection(dbConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var someValue = reader["ModuleName"].ToString();
                            results.Add(someValue);

                            // Do something with someValue
                        }
                    }
                }
            }

            return results;
        }
    }
}
