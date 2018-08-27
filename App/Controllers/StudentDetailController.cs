using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student.Data;
using Student.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static App.Models.StudentInputModel;

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
            var studentList = await _context.Students.Include(x => x.Standard).ToListAsync();

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
        public async Task<IActionResult> Create(StudentsInputDto studentDetail)
        {
            if (ModelState.IsValid)
            {
                Students student = new Students
                {
                    Name = studentDetail.Name,
                    FatherName = studentDetail.FatherName,
                    MotherName = studentDetail.MotherName,
                    RollNo = studentDetail.RollNo,
                    AddmissionDate = studentDetail.AddmissionDate,
                    CompeletionDate = studentDetail.CompeletionDate,
                    Standard = studentDetail.Standard,
                    Age = studentDetail.Age,
                    DOB = studentDetail.DOB
                };
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Student));
            }
            return View();
        }
         public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
           
            var studentDetail = await _context.Students.FindAsync(id);
            if (studentDetail == null)
            {
                return NotFound();
            }
            ViewBag.StandardList = standardsList;
            return View(studentDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentsInputDto students)
        {
            if (id != students.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var student = _context.Students.Where(p => p.Id == id).FirstOrDefault();
                    students.RollNo = student.RollNo;
                    students.Name = student.Name;
                    students.FatherName = student.FatherName; 
                    students.MotherName = student.MotherName;
                    students.DOB = student.DOB;
                    students.Age = student.Age;
                    students.Standard = student.Standard;
                    students.AddmissionDate = student.AddmissionDate;
                    students.CompeletionDate = student.CompeletionDate;
                    
                    
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Student));
            }
            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.StandardList = standardsList;
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stud = await _context.Students.FindAsync(id);
            _context.Students.Remove(stud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Student));
        }

        public IActionResult Details(Students student)
        {

            return View(student);

        }

        private bool StudentsExists(int id)
        {
            throw new NotImplementedException();
        }
    }
        
    
}