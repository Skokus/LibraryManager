using LibraryManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.WebApp.Controllers
{
    public class PublishHouseController : Controller
    {
        public IConfiguration Configuration;

        public PublishHouseController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostURL()
        {
            var result = Configuration["RestApiURL:HostURL"];
            return Content(result);
        }

        private string CN()
        {
            string cn = ControllerContext.RouteData.Values["controller"].ToString();
            return cn;
        }
        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostURL().Content + CN();
            List<PublishHouseVM> authorList = new List<PublishHouseVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    authorList = JsonConvert.DeserializeObject<List<PublishHouseVM>>(apiResponse);
                }
            }
            return View(authorList);
        }
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostURL().Content + CN();
            PublishHouseVM author = new PublishHouseVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<PublishHouseVM>(apiResponse);
                }
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PublishHouseVM author)
        {
            string _restpath = GetHostURL().Content + CN();
            PublishHouseVM result = new PublishHouseVM();
            using (var httpClient = new HttpClient())
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(author);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync($"{_restpath}/{author.Id}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<PublishHouseVM>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {

            string _restpath = GetHostURL().Content;
            PublishHouseVM s = new PublishHouseVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<PublishHouseVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublishHouseVM s)
        {

            string _restpath = GetHostURL().Content + CN();
            PublishHouseVM result = new PublishHouseVM();
            using (var httpClient = new HttpClient())
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync($"{_restpath}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<PublishHouseVM>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostURL().Content + CN();
            PublishHouseVM s = new PublishHouseVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<PublishHouseVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PublishHouseVM s)
        {
            string _restpath = GetHostURL().Content + CN();
            using (var httpClient = new HttpClient())
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize("");
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (var response = await httpClient.DeleteAsync($"{_restpath}/{s.Id}"))
                {

                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
