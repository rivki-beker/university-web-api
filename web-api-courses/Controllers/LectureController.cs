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
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lecutureService;
        private readonly IMapper _mapper;


        public LectureController(ILectureService lecutureService,IMapper mapper)
        {
            _lecutureService = lecutureService;
            _mapper = mapper;
        }

        // GET: api/<CourseController>/5/?id=&
        [HttpGet]
        public async Task<ActionResult> Get(string? address)
        {
            var list=await _lecutureService.GetAll(address);
            return Ok(_mapper.Map<IEnumerable<LectureDto>>(list));
        }

        // GET api/<LectureController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var lecture=await _lecutureService.GetById(id);
            return Ok(_mapper.Map<LectureDto>(lecture));
        }

        // POST api/<LectureController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] LecturePostModel lecture)
        {
            var l = _mapper.Map<Lecture>(lecture);
            await _lecutureService.Post(l);
            return Ok(_mapper.Map<LectureDto>(l));
        }

        // PUT api/<LectureController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Put(int id, [FromBody] LecturePostModel lecture)
        {
            var l = _mapper.Map<Lecture>(lecture);
            var lUpdated=await _lecutureService.Put(id,l );
            return Ok(_mapper.Map<LectureDto>(lUpdated));
        }

        // DELETE api/<LectureController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await _lecutureService.Delete(id);
        }
    }
}
