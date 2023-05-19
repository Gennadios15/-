using MySql.Data.MySqlClient;

namespace ImportData
{
    public class DBConnection
    {
        public List<Event> FetchData()
        {
            string serverIp = "unicalendar.mysql.database.azure.com";
            string username = "admin1";
            string password = "FEFEdeefa1732!";
            string databaseName = "unicalendar_db";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            string query = "SELECT EventName,Eventdetails,EventStartsOn,EventsEndsOn FROM event WHERE GoogleCalendarID = 1";

            List<Event> results = new List<Event>();

            using (var conn = new MySqlConnection(dbConnectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var eventObj = new Event
                            {
                                EventName = reader["EventName"].ToString(),
                                Eventdetails = reader["Eventdetails"].ToString(),
                                EventStartsOn = DateOnly.FromDateTime((DateTime)reader["EventStartsOn"]),
                                EventsEndsOn = DateOnly.FromDateTime((DateTime)reader["EventsEndsOn"])
                            };
                            results.Add(eventObj);
                        }
                    }
                }
            }
            return results;
        }
    }
}
