using Microsoft.AspNetCore.Mvc;
using ShamrockHeightsEvents.Models;
using ShamrockHeightsEvents.Data;
using ShamrockHeightsEvents.Models;
using Microsoft.AspNetCore.Authorization;

namespace ShamrockHeightsEvents.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsDBContext db;

        public EventsController(EventsDBContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Events.ToList());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add([Bind("Title, Description, Location, ImageUrl, Year, Month, Day, Time")] Event i)
        {
            i.VolunteerList = new List<string>();
            db.Events.Add(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            return View(db.Events.Find(id));
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit([Bind("Id, Title, Description, Location, ImageUrl, Year, Month, Day, Time")] Event i)
        {
            i.VolunteerList = new List<string>();
            db.Events.Update(i);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            db.Remove(db.Events.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
