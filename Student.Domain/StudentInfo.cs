using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Domain
{
   public class StudentInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public int RollNo { get; set; }
        public string Branch { get; set; }

        public Standard Standard { get; set; }
    }
}
