using web_api_courses.Entities;

namespace web_api_courses.Models
{
    public class CoursePostModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int MeetingsNum { get; set; }
        public int Age { get; set; }
        public int LectureId { get; set; }
    }
}
