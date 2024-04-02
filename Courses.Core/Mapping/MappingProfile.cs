using AutoMapper;
using Courses.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<LectureDto, Lecture>().ReverseMap();
            CreateMap<PupilDto, Pupil>().ReverseMap();
        }
    }
}
