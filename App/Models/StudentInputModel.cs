using Student.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace App.Models
{
    public class StudentInputModel
    {
        public class StudentsInputDto
        {
            [Required]
            public int Id { get; set; }
            [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Only characters are allowed in Name!")]
            [Required]
            public string Name { get; set; }
            [Required]
            public int RollNo { get; set; }
            [Required]
            public DateTime DOB { get; set; }
            [Required]
            public int Age { get; set; }
            [Required]
            public DateTime AddmissionDate { get; set; }
            [Required]
            public DateTime CompeletionDate { get; set; }
            [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Only characters are allowed in Father Name!")]
            [Required]
            public string FatherName { get; set; }
            [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Only characters are allowed in Mother Name!")]
            [Required]
            public string MotherName { get; set; }

            public int StandardId { get; set; }
            public Standard Standard { get; set; }

        }
      
    }
}
