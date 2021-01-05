using RescueRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RescueRegister.Controllers
{
    public class MountaineerController : Controller
    {
        private readonly RescueRegisterDbContext context;

        public MountaineerController(RescueRegisterDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new RescueRegisterDbContext())
            {
                var allMountaineers = db.Mountaineers.ToList();
                return View(allMountaineers);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Mountaineer mountaineer)
        {
            //if (string.IsNullOrEmpty(mountaineer))
            //{
            //    return RedirectToAction("Index");
            //}

            Mountaineer human = new Mountaineer
            {
                Name = mountaineer.Name,
                Age = mountaineer.Age,
                Gender = mountaineer.Gender,
                LastSeenDate = mountaineer.LastSeenDate
            };
            using (var db = new RescueRegisterDbContext())
            {
                db.Mountaineers.Add(human);
                db.SaveChanges();
            }
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var humanToEdit = db.Mountaineers.FirstOrDefault(t => t.Id == id);
                if (humanToEdit==null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(humanToEdit);
            }

        }

        [HttpPost]
        public IActionResult Edit(Mountaineer mountaineer)
        {
            Mountaineer human = new Mountaineer
            {
                Name = mountaineer.Name,
                Age = mountaineer.Age,
                Gender = mountaineer.Gender,
                LastSeenDate = mountaineer.LastSeenDate
            };
            using (var db = new RescueRegisterDbContext())
            {
                db.Mountaineers.Add(human);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var humanToDelete = db.Mountaineers.FirstOrDefault(t => t.Id == id);
                if (humanToDelete == null)
                {
                    RedirectToAction("Index");
                }
                db.Mountaineers.Remove(humanToDelete);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Mountaineer mountaineer)
        {
            // TODO: Implement me
            return null;
        }
    }
}