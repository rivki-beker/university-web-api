using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Core.Services
{
    public interface IPupilService
    {
        Task<List<Pupil>> GetAll();

        Task<Pupil> GetById(int id);

        Task<Pupil> Post( Pupil pupil);

        Task<Pupil> Put(int id,Pupil pupil);

        Task<Pupil> AddYear(int id);

        Task Delete(int id);
    }
}
