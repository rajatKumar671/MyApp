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
            var standardlist = await _contexts.Standards.ToListAsync();
            return View(standardlist.OrderBy(s=>s.StandardName));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StandardInputDto standard)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var standards = _mapper.Map<Standard>(standard);
                    _contexts.Add(standards);
                    await _contexts.SaveChangesAsync();
                    return RedirectToAction(nameof(Standard));
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
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


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var standard = await _contexts.Standards.FindAsync(id);
            if (standard != null)
            {
                _contexts.Standards.Remove(standard);
                await _contexts.SaveChangesAsync();
                return RedirectToAction(nameof(Standard));
            }
            ModelState.AddModelError("", "Standard not found");
            return View(ModelState);
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
                    var standards = _contexts.Standards.Where(_ => _.Id == id).FirstOrDefault();
                    if (standards != null)
                    {
                       standards.StandardName = standard.StandardName;
                        await _contexts.SaveChangesAsync();
                        return RedirectToAction("Standard");
                    }
                    ModelState.AddModelError("", "Standard not found");
                    return View(ModelState);
                }
            }
            return View();
        }
    }
}