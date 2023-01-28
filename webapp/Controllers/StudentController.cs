using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using webapp.Models;

namespace webapp.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext db;
        public StudentController(StudentContext _db)
        {
            db = _db;        
        }
        public IActionResult Index()
        {
            var list =  db.Tb_Student.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentModel std)
        {
            if (std !=null)
            {
                if (std.StudentId == 0)
                {
                    db.Tb_Student.Add(std);                    
                }
                else
                {
                    db.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var obj = db.Tb_Student.Find(id);
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = db.Tb_Student.Find(id);
            db.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
