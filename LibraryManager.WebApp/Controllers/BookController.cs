using LibraryManager.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.WebApp.Controllers
{
    public class BookController : Controller
    {
        public IConfiguration Configuration;

        public BookController(IConfiguration configuration)
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
            List<BookVM> authorList = new List<BookVM>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    authorList = JsonConvert.DeserializeObject<List<BookVM>>(apiResponse);
                }
            }
            return View(authorList);
        }

        public async Task<IActionResult> Create()
        {
            string _restpath = GetHostURL().Content;
            BookVM s = new BookVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<BookVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookVM s)
        {
            string _authorRestpath = GetHostURL().Content + "Author";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_authorRestpath}/{s.Author.Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    AuthorVM yarnType = JsonConvert.DeserializeObject<AuthorVM>(apiResponse);
                }
            }

            string _publishHouseRestpath = GetHostURL().Content + "PublishHouseVM";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_publishHouseRestpath}/{s.PublishHouse.Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    PublishHouseVM yarnType = JsonConvert.DeserializeObject<PublishHouseVM>(apiResponse);
                }
            }

            string _restpath = GetHostURL().Content + CN();
            BookVM result = new BookVM();
            using (var httpClient = new HttpClient())
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync($"{_restpath}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<BookVM>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostURL().Content + CN();
            BookVM s = new BookVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<BookVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookVM s)
        {
            string _authorRestpath = GetHostURL().Content + "Author";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_authorRestpath}/{s.Author.Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    AuthorVM yarnType = JsonConvert.DeserializeObject<AuthorVM>(apiResponse);
                }
            }

            string _publishHouseRestpath = GetHostURL().Content + "PublishHouseVM";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_publishHouseRestpath}/{s.PublishHouse.Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    PublishHouseVM yarnType = JsonConvert.DeserializeObject<PublishHouseVM>(apiResponse);
                }
            }

            string _restpath = GetHostURL().Content + CN();
            BookVM result = new BookVM();
            using (var httpClient = new HttpClient())
            {
                string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync($"{_restpath}/{s.Id}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<BookVM>(apiResponse);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {

            string _restpath = GetHostURL().Content + CN();
            BookVM s = new BookVM();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<BookVM>(apiResponse);
                }
            }
            return View(s);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(BookVM s)
        {
            //string _restpath = "http://localhost:5000/SkiJumper";

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
