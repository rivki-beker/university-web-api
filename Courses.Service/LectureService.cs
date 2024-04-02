using Courses.Core.Repositories;
using Courses.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api_courses.Entities;

namespace Courses.Service
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectures;

        public LectureService(ILectureRepository lectures)
        {
            _lectures = lectures;
        }
        public async Task<List<Lecture>> GetAll(string? address)
        {
            var list = await _lectures.GetList();
            return list.Where(c => address == null || c.Address == address).ToList();
        }

        public async Task<Lecture> GetById(int id)
        {
            var list = await _lectures.GetList();
            Lecture? res = list.Find(x => x.Id == id);
            if (res == null)
                throw new Exception("404");
            return res;
        }

        public async Task<Lecture> Post(Lecture lecture)
        {
            return await _lectures.Post(lecture);
        }

        public async Task<Lecture> Put(int id, Lecture lecture)
        {
            return await _lectures.Put(id, lecture);
        }

        public async Task Delete(int id)
        {
            var list = await _lectures.GetList();
            Lecture? res =list.Find(x => x.Id == id);
            if (res != null)
               await  _lectures.Delete(res);
        }
    }
}
