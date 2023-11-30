namespace toiec_web.Models
{
    public class Lesson
    {
        public Guid idLesson { get; set; }
        public Guid idCourse { get; set; }
        public string title { get; set;}
        public string content { get; set;}
        public virtual Course Course { get; set;}
        public virtual ICollection<Quiz> Quizzes { get; set;}
    }
}
