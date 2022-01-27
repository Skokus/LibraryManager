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
    public class FilmStudioController : Controller
    {
        public IConfiguration Configuration;

        public FilmStudioController(IConfiguration configuration)
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
            List<FilmStudioVM> authorList = new List<FilmStudioVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    authorList = JsonConvert.DeserializeObject<List<FilmStudioVM>>(apiResponse);
                }
            }
            return View(authorList);
        }
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostURL().Content + CN();
            FilmStudioVM author = new FilmStudioVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<FilmStudioVM>(apiResponse);
                }
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FilmStudioVM author)
        {
            string _restpath = GetHostURL().Content + CN();
            FilmStudioVM result = new FilmStudioVM();
            using (var httpClient = new HttpClient())
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(author);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync($"{_restpath}/{author.Id}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    author = JsonConvert.DeserializeObject<FilmStudioVM>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {

            string _restpath = GetHostURL().Content;
            FilmStudioVM s = new FilmStudioVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<FilmStudioVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilmStudioVM s)
        {

            string _restpath = GetHostURL().Content + CN();
            FilmStudioVM result = new FilmStudioVM();
            using (var httpClient = new HttpClient())
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync($"{_restpath}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<FilmStudioVM>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostURL().Content + CN();
            FilmStudioVM s = new FilmStudioVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<FilmStudioVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FilmStudioVM s)
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
