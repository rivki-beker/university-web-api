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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courses;

        public CourseService(ICourseRepository courses)
        {
            _courses = courses;
        }

        public async Task<List<Course>> GetAll(string? name, int? age)
        {
            var list = await _courses.GetList();
            return list.Where(c => (name == null || c.Name == name) && (age == null || c.Age == age)).ToList();
        }
        public async Task<Course> GetById(int id)
        {
            var list = await _courses.GetList();
            Course? res = list.Find(x => x.Id == id);
            if (res == null)
                throw new Exception("404");
            return res;
        }
        public async Task<Course> Post(Course course)
        {
            return await _courses.Post(course);
        }

        public async Task<Course> Put(int id,Course course)
        {
            return await _courses.Put(id, course);
        }

        public async Task Delete(int id)
        {
            var list = await _courses.GetList();
            Course? res = list.Find(x => x.Id == id);
            if (res != null)
                await _courses.Delete(res);
        }
    }
}