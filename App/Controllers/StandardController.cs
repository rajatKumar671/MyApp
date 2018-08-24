using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Data;
using Student.Domain;
using static App.Models.StudentInputModel;

namespace App.Controllers
{
    public class StandardController : Controller
    {
        private readonly StudentContext _contexts;
        public StandardController(StudentContext context)
        {
            _contexts = context;
        }
        public async Task<IActionResult> Standard()
        {
            ViewBag.Title = "Standard";
            return View(await _contexts.Standards.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StandardInputDto standard)
        {

            if (ModelState.IsValid)
            {
                Standard ob = new Standard();
                ob.StandardName = standard.StandardName;
                _contexts.Add(ob);
                await _contexts.SaveChangesAsync();
                return RedirectToAction(nameof(Standard));
            }
            return View();
        }
        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standard = await _contexts.Standards
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);
            if (standard == null)
            {
                return NotFound();
            }

            return View(standard);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stud = await _contexts.Standards.FindAsync(id);
            _contexts.Standards.Remove(stud);
            await _contexts.SaveChangesAsync();
            return RedirectToAction(nameof(Standard));
        }
        public ActionResult Edit(int id)
        {
            using (_contexts)
            {
                return View(_contexts.Standards.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Standard standards)
        {
            try
            {
                using (_contexts)
                {
                    _contexts.Entry(standards).State = EntityState.Modified;
                    _contexts.SaveChanges();

                }
                return RedirectToAction("Standard");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }

}