using Student.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace App.Models
{
    public class StudentInputModel:IValidatableObject
    {
        public class StandardInputDto
        {
            public int Id { get; set; }

            [Required]
            public string StandardName { get; set; }
        }
        public class StudentsInputDto
        {
            [Required]
            public int Id { get; set; }
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
            [Required]
            public string FatherName { get; set; }
            [Required]
            public string MotherName { get; set; }

            public int StandardId { get; set; }
            public Standard Standard { get; set; }

        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
