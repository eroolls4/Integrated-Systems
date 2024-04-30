using EShopAdminApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace EShopAdminApplication.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "https://localhost:7112/api/Admin/GetAllOrders";

            HttpResponseMessage response = client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Order>>(responseData);
                return View(data);
            }
            else
            {
                // Handle the error case here
                // For example, return a view indicating the error
                return View("Error");
            }
        }

        public IActionResult Details(string id)
        {
            HttpClient client = new HttpClient();
            string URL = "https://localhost:7112/api/Admin/GetDetails";
            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Order>(responseData);
                return View(result);
            }
            else
            {
                // Handle the error case here
                // For example, return a view indicating the error
                return View("Error");
            }
        }

    }
}