using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student.Data;
using Student.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class StudentDetailController : Controller
    {
        private readonly StudentContext _context;

        public StudentDetailController(StudentContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Student()
        {
            var studentList = await _context.Students.Include(x=>x.Standard).ToListAsync();

            return View(studentList);
        }

        public IActionResult Create()
        {
            var standards = _context.Standards.ToList();
            List<SelectListItem> standardsList = new List<SelectListItem>();
            foreach (var standard in standards)
            {
                standardsList.Add(new SelectListItem
                {
                    Text = standard.StandardName,
                    Value = standard.Id.ToString()
                });
            }
            ViewBag.StandardList = standardsList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Students studentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Student));
            }
            return View(studentDetail);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var stud = await _context.Students.FindAsync(id);
            _context.Students.Remove(stud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Student));
        }

        public async Task<IActionResult>Details( Students student)
        {
            return View(student);
        }
    }
  
}