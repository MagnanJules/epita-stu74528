using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebApp.Domain.Models;

namespace WebApp.MVC.Controllers
{
    public class BikeController : Controller
    {

        private string contract;
        private string apiKey;
        string contractAndKey;
     //  Uri baseAddress0 = new Uri("https://api.jcdecaux.com/vls/v1/stations?contract=Dublin&apiKey=3aa66c7d23f6a40af417fc87ba25d34c2d285d4a");
        Uri baseAddress = new Uri("https://api.jcdecaux.com/vls/v1/stations");

        private readonly HttpClient _httpClient;

        private readonly IMapper _mapper;

        public BikeController(IMapper mapper)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            contract = "Dublin";
            apiKey = "3aa66c7d23f6a40af417fc87ba25d34c2d285d4a";
            contractAndKey = $"contract={contract}&apiKey={apiKey}";
            _mapper = mapper;
        }
        // GET: BikeController
        public ActionResult Index()
        {
            List<BikeStation> bikeStations = new();

            Console.WriteLine($"{baseAddress}?{contractAndKey}");
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{baseAddress}?{contractAndKey}").Result;


            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                bikeStations = JsonConvert.DeserializeObject<List<BikeStation>>(data);
            }


            return View(bikeStations);
        }

        // GET: BikeController/Details/5
        public ActionResult Details(int id)
        {
            BikeStation bikeStation = new();

            Console.WriteLine($"{baseAddress}/{id}?{contractAndKey}");
            HttpResponseMessage httpResponseMessage = _httpClient.GetAsync($"{baseAddress}/{id}?{contractAndKey}").Result;


            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                bikeStation = JsonConvert.DeserializeObject<BikeStation>(data);
            }


            var dto = _mapper.Map<BikeStationDTO>(bikeStation);

            //return View(bikeStation);
            return View(dto);




        }

        // GET: BikeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BikeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BikeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BikeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BikeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
