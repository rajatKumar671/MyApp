using Student.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App
{
    public class StandardInputModel
    { 
        public class StandardInputDto
        {
            public int Id { get; set; }

            [Required]
            public string StandardName { get; set; }

            public List<Students> Students { get; set; }
        }
        
    }
}
