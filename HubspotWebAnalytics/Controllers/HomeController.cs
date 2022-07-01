using HubspotWebAnalytics.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace HubspotWebAnalytics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration { get; }
        //Destination API key
        public static string DestinationAPIKey = "";

        public HomeController(ILogger<HomeController> logger, IConfiguration IConfig)
        {
            _logger = logger;
            _configuration = IConfig;
            DestinationAPIKey = _configuration.GetSection("HubspotWebAnalyticsSettings").GetSection("DestinationAPIKey").Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateContact(HubspotContactModel Contact)
        {
            //These are the URI(s) that contain the API key for Contacts
            string initContactv3 = "https://api.hubapi.com/crm/v3/objects/contacts?hapikey=" + DestinationAPIKey;

            try
            {
                using (var client = new HttpClient())
                {
                    var myContent = JsonConvert.SerializeObject(Contact,
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    client.BaseAddress = new Uri(initContactv3);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsync("", byteContent).Result;
                    var readTask = response.Content.ReadAsStringAsync().Result;

                    //GET Method
                    if (response.IsSuccessStatusCode)
                    {
                        string success = (response.ReasonPhrase
                                + ": "
                                + "Successfully Created the Contact: " + Contact.firstname + " " + Contact.lastname);
                        _logger.LogTrace(success);
                    }
                    else
                    {
                        string fail = (response.ReasonPhrase
                                + ": "
                                + "Failed to Created the Contact: " + Contact.firstname + " " + Contact.lastname);
                        _logger.LogTrace(fail);
                    }
                }
            }
            catch (Exception e)
            {
                string fail = (e
                    +
                    ": "
                    + "Failed to Created the Contact: " + Contact.firstname + " " + Contact.lastname);
                _logger.LogTrace(fail);
            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}