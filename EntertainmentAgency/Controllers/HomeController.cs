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

        public IActionResult Entertainers()
        {
            var entertainers = repository.GetAllEntertainers();
            if (entertainers == null)
            {

                entertainers = new List<Entertainer>();
            }
            return View(entertainers);
        }

        public IActionResult EntertainerDetails(int id)
        {
            var entertainer = repository.GetEntertainerById(id);
            if (entertainer == null)
            {
                return NotFound(); 
            }
            return View(entertainer); 
        }

        public IActionResult Create()
        {
            return View(new Entertainer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Entertainer entertainer)
        {
            if (ModelState.IsValid)
            {
                repository.AddEntertainer(entertainer);
                return RedirectToAction(nameof(Entertainers)); 
            }
            return View(entertainer);
        }

        public IActionResult Edit(int id)
        {
            var entertainer = repository.GetEntertainerById(id);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }

        [HttpPost]
        public IActionResult Edit(Entertainer entertainer)
        {
            if (ModelState.IsValid)
            {
                repository.UpdateEntertainer(entertainer);
                return RedirectToAction(nameof(Index));
            }
            return View(entertainer);
        }

        public IActionResult Delete(int id)
        {
            var entertainer = repository.GetEntertainerById(id);
            if (entertainer == null)
            {
                return NotFound();
            }
            return View(entertainer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            repository.DeleteEntertainer(id);
            return RedirectToAction(nameof(Index)); // Adjust as needed
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
