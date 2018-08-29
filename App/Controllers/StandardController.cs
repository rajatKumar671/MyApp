using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Data;
using Student.Domain;
using static App.StandardInputModel;

namespace App.Controllers
{
    public class StandardController : Controller
    {
        private readonly IMapper _mapper;
        private readonly StudentContext _contexts;
        public StandardController(StudentContext context, IMapper mapper)
        {
            _mapper = mapper;
            _contexts = context;
        }
        public async Task<IActionResult> Standard()
        {
            ViewBag.Title = "Standard";
            var a = await _contexts.Standards.ToListAsync();
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
                var standards = _mapper.Map<Standard>(standard);
                _contexts.Add(standards);
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
        public async Task<IActionResult> Edit(int id, StandardInputDto standard)
        {
            if (ModelState.IsValid)
            {
                using (_contexts)
                {
                    var standart = _contexts.Standards.Where(_ => _.Id == id).FirstOrDefault();
                    standart.StandardName = standard.StandardName;
                     _contexts.SaveChanges();
                    return RedirectToAction("Standard");
                }
            }
            return View();
        }
    }
}