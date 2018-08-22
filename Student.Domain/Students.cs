using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Domain
{
   public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public DateTime AddmissionDate { get; set; }
        public DateTime CompeletionDate { get; set; }

        public int StandardId { get; set; }
        public Standard Standard { get; set; }
        
    }
}
