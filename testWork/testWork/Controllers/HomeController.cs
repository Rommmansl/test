using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using testWork.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        int test = 0;
        IWebHostEnvironment _appEnvironment;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public async Task<IActionResult> Index(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                int salaries = 0;
                string path = uploadedFile.FileName;
                using (var fileStream = new FileStream("C:/wwwroot/" + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                StreamReader sr = new StreamReader("C:/wwwroot/" + path);
                string jsonString = sr.ReadToEnd();

                dynamic files = JsonConvert.DeserializeObject(jsonString);
                for (int i = 0; i < files.Count; i++)
                {
                    if (files[i].positon == "manager")
                    {
                        Worker money = new Manager(Convert.ToInt32(files[i].salary));
                        money = new Bonus(money, Convert.ToInt32(files[i].bonus));
                        salaries += money.GetSalary();
                    }
                    if (files[i].positon == "technician")
                    {
                        Worker money = new Technician(Convert.ToInt32(files[i].salary));
                        string s = files[i].category;
                        money = new Category(money, s);
                        money = new Bonus(money, Convert.ToInt32(files[i].bonus));
                        salaries += money.GetSalary();
                    }
                    if (files[i].positon == "driver")
                    {
                        Worker money = new Driver(Convert.ToInt32(files[i].salary), Convert.ToInt32(files[i].timeWorked));
                        string s = files[i].category;
                        money = new Category(money, s);
                        money = new Bonus(money, Convert.ToInt32(files[i].bonus));
                        salaries += money.GetSalary();
                    }
                }
                ViewData["Message"] = salaries;
            }

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
