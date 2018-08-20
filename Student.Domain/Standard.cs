using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Domain
{
   public class Standard
    {
        public int Id { get; set; }
        public string StandardName { get; set; } 
        public List<Students> Students { get; set; }
    }
}
