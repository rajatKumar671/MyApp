using AutoMapper;
using Student.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Students, StudentInputModel>().ReverseMap();
            CreateMap<Standard, StandardInputModel>().ReverseMap();
            CreateMap<StandardInputModel, Standard>()
                .ForMember(s => s.Students, a => a.Ignore());
        }
    }
}
