using BugVue.Data;
using BugVue.Models;
using Microsoft.AspNetCore.Mvc;

namespace BugVue.Controllers
{
    public class BugController : Controller
    {
        private readonly BugDb _db;

        public BugController(BugDb bugDb)
        {
            _db = bugDb;
        }

        [Route("/bug")]
        [HttpGet]
        public IActionResult Get()
        {
            var model = _db.Bugs;
            return Ok(model);
        }

        [Route("/bug/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var model = _db.Bugs.Find(id);
            return Ok(model);
        }

        [Route("/bug")]
        [HttpPost]
        public IActionResult Post(Bug model)
        {
            _db.Bugs.Add(model);
            _db.SaveChanges();

            return Ok(model);
        }

        [Route("/bug")]
        [HttpPut]
        public IActionResult Put(Bug model)
        {
            var bug = _db.Bugs.Find(model.Id);
            bug.Name = model.Name;
            bug.Description = model.Description;

            _db.SaveChanges();

            return Ok(model);
        }

        [Route("/bug")]
        [HttpDelete]
        public IActionResult Delete(Bug model)
        {
            var bug = _db.Bugs.Find(model.Id);

            _db.Bugs.Remove(bug);
            _db.SaveChanges();

            return Ok(model);
        }
    }
}