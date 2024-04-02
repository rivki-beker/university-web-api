namespace web_api_courses.Entities
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }

        public List<Course> Courses { get; set; }
    }
}
