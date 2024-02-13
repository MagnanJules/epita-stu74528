using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Domain.Models;

namespace WebApp.MVC.Controllers
{
    public class UserProfileController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7033/api/v1/UserProfile");

        private readonly HttpClient _httpClient;

        public UserProfileController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<UserProfile> userProfiles = new();

            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(baseAddress).Result;


            if(httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                userProfiles = JsonConvert.DeserializeObject<List<UserProfile>>(data);    
            }


            return View(userProfiles);
        }
    }
}
