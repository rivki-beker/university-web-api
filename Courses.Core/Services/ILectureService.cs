using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Services
{
    public interface ILectureService
    {
        Task<List<Lecture>> GetAll(string? address);

        Task<Lecture> GetById(int id);

        Task<Lecture> Post( Lecture lecture);

        Task<Lecture> Put(int id, Lecture lecture);

        Task Delete(int id);
}
}
