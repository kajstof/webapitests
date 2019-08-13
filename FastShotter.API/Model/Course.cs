namespace FastShotter.API
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}