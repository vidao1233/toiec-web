namespace toeic_web.Models
{
    public class Professor
    {
        public Guid idProfessor { get; set; }
        public string idUser { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Vocabulary> Vocabularies { get; set; }
        public virtual ICollection<VocTopic> VocTopics { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
