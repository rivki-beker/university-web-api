using AutoMapper;
using Courses.Core.DTOs;
using Courses.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using web_api_courses.Entities;
using web_api_courses.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api_courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    []
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService,IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        // GET: api/<CourseController>/5/?id=&
        [HttpGet]
        public async Task<ActionResult> Get(string? name, int? age)
        {
            var list=await _courseService.GetAll(name,age);
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(list));
        }
        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<CourseDto> Get(int id)
        {
            var course=await _courseService.GetById(id);
            return _mapper.Map<CourseDto>(course);
        }
        // POST api/<CourseController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] CoursePostModel course)
        {
            var c = _mapper.Map<Course>(course);
            await _courseService.Post(c);
            return Ok(_mapper.Map<CourseDto>(c));
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, [FromBody] CoursePostModel course)
        {
            var c = _mapper.Map<Course>(course);
            var cUpdated= await _courseService.Put(id, c);
            return Ok(_mapper.Map<CourseDto>(cUpdated));
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _courseService.Delete(id);
        }
    }
}
