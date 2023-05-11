using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace ImportData.Controllers
{
    public class CalendarController : Controller
    {
        private string connectionString = "Server=unicalendar.mysql.database.azure.com;Database=unicalendar_db;User Id=admin1;Password=FEFEdeefa1732!;SslMode=Preferred;";
        private string applicationName = "UniCalendar";
        private string calendarId = "86635dbe0402a162b5696c07ff4f49d83a2b6452778660fc57703361e1835b58@group.calendar.google.com";
        private string serviceAccountEmail = "georgepolz02@gmail.com";
        private string serviceAccountKeyFilePath = "./credential_service.json";

        // GET: Calendar/ImportEvents
        public ActionResult ImportEvents()
        {
            try
            {
                var credential = GetServiceAccountCredential();

                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName,
                });

                var connection = new MySqlConnection(connectionString);
                var command = new MySqlCommand("SELECT EventName, EventStartsOn, EventsEndsOn FROM event WHERE EventId = 1", connection);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var eventName = reader.GetString(0);
                    var eventStart = DateOnly.FromDateTime(reader.GetDateTime(1));
                    var eventEnd = DateOnly.FromDateTime(reader.GetDateTime(2));

                    var newEvent = new Google.Apis.Calendar.v3.Data.Event()
                    {
                        Summary = eventName,
                        Start = new EventDateTime()
                        {
                            Date = eventStart.ToString(),
                        },
                        End = new EventDateTime()
                        {
                            Date = eventEnd.ToString(),
                        },
                    };

                    var request = service.Events.Insert(newEvent, calendarId);
                    request.Execute();
                }

                ViewBag.Message = "Events imported successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error importing events: " + ex.Message;
                ViewBag.StackTrace = ex.StackTrace;
            }

            return View("~/Views/Home/ImportEvents.cshtml");

        }

        private GoogleCredential GetServiceAccountCredential()
        {
            var keyFileStream = new FileStream(serviceAccountKeyFilePath, FileMode.Open, FileAccess.Read);
            var credential = GoogleCredential.FromStream(keyFileStream)
                .CreateScoped(new[] { CalendarService.Scope.Calendar });

            return credential;
        }
    }
}
