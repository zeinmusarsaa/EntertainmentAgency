using EntertainmentAgency.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntertainmentAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntertainerRepository repository;


        public HomeController(IEntertainerRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Entertainers()
        {
            return View();
        }

        public IActionResult EntertainerDetails()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
