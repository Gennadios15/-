using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImportData.Controllers
{
    public class CalendarController : Controller
    {
        private string serviceAccountKeyFilePath = "./credential_service.json";
        private readonly IConfiguration _configuration;

        public CalendarController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult CheckConnection()
        {
            try
            {
                var credential = GetServiceAccountCredential();

                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = _configuration["GoogleApi:ApplicationName"],
                });

                var calendarId = _configuration["GoogleApi:CalendarId"];
                var request = service.Events.List(calendarId);
                request.SingleEvents = true;
                request.MaxResults = 10;
                request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

                var events = request.Execute();

                // Return the events list as a JSON response
                var filteredEvents = events.Items.Select(e => new
                {
                    e.Id,
                    e.Summary,
                    e.Location,
                    e.Start.DateTime,
                });

                // Convert the filtered events list to a formatted JSON string
                var formattedJson = JsonConvert.SerializeObject(new { success = true, message = "Connection to Google API successful!", events = filteredEvents }, Formatting.Indented);

                // Return the formatted JSON string as a Content Result with the application/json content type
                return Content(formattedJson, "application/json");
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework
                return Json(new { success = false, message = "Error connecting to the Google API: " + ex.Message });
            }
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
