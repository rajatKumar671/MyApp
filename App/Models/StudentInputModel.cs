using Student.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class StudentInputModel: Students
    {
        public List<Standard> StandardsList { get; set; }
    }
}
