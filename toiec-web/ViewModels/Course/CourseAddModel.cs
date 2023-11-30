namespace toiec_web.ViewModels.Course
{
    public class CourseAddModel
    {
        public Guid idCourse { get; set; }
        public Guid idProfessor { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
