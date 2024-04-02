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
    public class PupilService : IPupilService
    {
        private readonly IPupilRepository _pupils;

        public PupilService(IPupilRepository pupils)
        {
            _pupils = pupils;
        }

        public async Task<List<Pupil>> GetAll()
        {
            return await _pupils.GetList();
        }

        public async Task<Pupil> GetById(int id)
        {
            var list = await _pupils.GetList();
            Pupil? res = list.Find(x => x.Id == id);
            if (res == null)
                throw new Exception("404");
            return res;
        }

        public async Task<Pupil> Post(Pupil pupil)
        {
            return await _pupils.Post(pupil);
        }

        public async Task<Pupil> Put(int id, Pupil pupil)
        {
            return await _pupils.Put(id, pupil);
        }

        public async Task<Pupil> AddYear(int id)
        {
            var list = await _pupils.GetList();
            Pupil? res = list.Find(x => x.Id == id);
            if (res == null)
                throw new Exception("404");
            res.Age++;
            return await _pupils.Put(res.Id, res);
        }

        public async Task Delete(int id)
        {
            var list = await _pupils.GetList();
            Pupil? res = list.Find(x => x.Id == id);
            if (res != null)
                await _pupils.Delete(res);
        }
    }
}
