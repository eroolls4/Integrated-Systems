using AdminApplication.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdminApplication.Controllers
{
    public class ConcertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportConcerts(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is not selected or empty.");
            }

            // Use a unique name for the uploaded file to avoid conflicts
            string uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
            string pathToUpload = Path.Combine(Directory.GetCurrentDirectory(), "files", uniqueFileName);

            try
            {
                // Ensure the files directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(pathToUpload));

                // Upload the file
                using (FileStream fileStream = new FileStream(pathToUpload, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }

                // Process the file
                List<Concert> concerts = getAllConcertsFromFile(pathToUpload);

                // Send the concerts to the API
                HttpClient client = new HttpClient();
                string URL = "http://localhost:5054/api/Admin/ImportAllConcerts";
                HttpContent content = new StringContent(JsonConvert.SerializeObject(concerts), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(URL, content).Result;

                var data = response.Content.ReadAsAsync<bool>().Result;
                return RedirectToAction("Index", "Order");
            }
            catch (Exception ex)
            {
                // Log the exception (use your preferred logging framework)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //private List<Concert> getAllConcertsFromFile(string fileName)
        //{
        //    List<Concert> concerts = new List<Concert>();
        //    string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";
        //    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        //    using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
        //    {


        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            while (reader.Read())
        //            {
        //                concerts.Add(new Concert
        //                {
        //                    ConcertName = reader.GetValue(0).ToString(),
        //                    ConcertDescription = reader.GetValue(1).ToString(),
        //                    ConcertImage = reader.GetValue(2).ToString(),
        //                    Rating=Int64.Parse(reader.GetValue(3).ToString())
        //                });

        //            }
        //        }
        //    }
        //    return concerts;
        //}

        private List<Concert> getAllConcertsFromFile(string filePath)
        {
            List<Concert> concerts = new List<Concert>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            concerts.Add(new Concert
                            {
                                ConcertName = reader.GetValue(0).ToString(),
                                ConcertDescription = reader.GetValue(1).ToString(),
                                ConcertImage = reader.GetValue(2).ToString(),
                                Rating = Convert.ToDouble(reader.GetValue(3))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (use your preferred logging framework)
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                throw;
            }

            return concerts;
        }
    }
}
