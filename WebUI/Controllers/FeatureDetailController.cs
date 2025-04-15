using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.DTOs;
using WebUI.DTOs.FeatureDetailDtos;

namespace WebUI.Controllers
{
    public class FeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7034/api/FeatureDetails/getall");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<RootResponse<List<GetFeatureDetailDto>>>(jsonData);
                if (values.Success)
                {
                    TempData["SuccessMessage"] = values.Message;
                    return View(values.Data);
                }
                else TempData["ErrorMessage"] = values.Message;
                return View(new List<GetFeatureDetailDto>());
            }
            TempData["ErrorMessage"] = "Serverə qoşulmaq mümkün olmadı.";
            return View(new List<GetFeatureDetailDto>());
        }
        [HttpGet]
        public IActionResult CreateFeatureDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureDetail(CreateFeatureDetailDto createFeatureDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7034/api/FeatureDetails", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeatureDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7034/api/FeatureDetails/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<RootResponse<UpdateFeatureDetailDto>>(jsonData);
                if (values.Success)
                {
                    TempData["SuccessMessage"] = values.Message;
                    return View(values.Data);
                }
                else TempData["ErrorMessage"] = values.Message;
                return View(new List<GetFeatureDetailDto>());
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureDetail(UpdateFeatureDetailDto updateFeatureDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7034/api/FeatureDetails", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteFeatureDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7034/api/AboutDetails/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
