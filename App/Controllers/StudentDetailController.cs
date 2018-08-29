using App.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly StudentContext _context;

        public StudentDetailController(IMapper mapper, StudentContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public async Task<IActionResult> Student()
        {
            var studentList = await _context.Students.Include(x => x.Standard).ToListAsync();
  
            return View(studentList.OrderBy(s => s.Name));
        }

        /*   public IActionResult Create()
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
                      RollNo = studentDetail.RollNo,
                      FatherName = studentDetail.FatherName,
                      MotherName = studentDetail.MotherName,
                      Age = studentDetail.Age,
                      DOB = studentDetail.DOB,
                      AddmissionDate = studentDetail.AddmissionDate,
                      CompeletionDate = studentDetail.CompeletionDate,
                      StandardId=studentDetail.StandardId,
                      Standard = studentDetail.Standard
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
                              student.RollNo=students.RollNo;
                              student.Name=students.Name;
                              student.FatherName=students.FatherName; 
                              student.MotherName=students.MotherName;
                              student.DOB=students.DOB;
                              student.Age=students.Age;
                              student.Standard=students.Standard;
                              student.AddmissionDate= students.AddmissionDate;
                              student.CompeletionDate= students.CompeletionDate;


                              _context.Update(student);
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
                  }*/
        public async Task<ActionResult> CreateEdit(int? id)
        {
            if (id == null)
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
            if (id != null)
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

                var studentDetail = await _context.Students.FindAsync(id);
                if (studentDetail == null)
                {
                    return NotFound();
                }
                ViewBag.StandardList = standardsList;
                return View(studentDetail);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>CreateEdit(int? id, StudentsInputDto students)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    /*Students student = new Students
                    {
                        Name = students.Name,
                        RollNo = students.RollNo,
                        FatherName = students.FatherName,
                        MotherName = students.MotherName,
                        Age = students.Age,
                        DOB = students.DOB,
                        AddmissionDate = students.AddmissionDate,
                        CompeletionDate = students.CompeletionDate,
                        StandardId = students.StandardId,
                        Standard = students.Standard
                    };*/
                    var student = _mapper.Map<Students>(students);
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Student));
                }
            }
            if(id!=null)
            {
                try
                {
                    /* var student = _context.Students.Where(p => p.Id == id).FirstOrDefault();
                     student.RollNo = students.RollNo;
                     student.Name = students.Name;
                     student.FatherName = students.FatherName;
                     student.MotherName = students.MotherName;
                     student.DOB = students.DOB;
                     student.Age = students.Age;
                     student.Standard = students.Standard;
                     student.AddmissionDate = students.AddmissionDate;
                     student.CompeletionDate = students.CompeletionDate;*/

                    var student = _mapper.Map<Students>(students);
                    _context.Update(student);
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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (ModelState != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Student));
            }
            ModelState.AddModelError("", "Student Details not found");
            return View(ModelState);
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
