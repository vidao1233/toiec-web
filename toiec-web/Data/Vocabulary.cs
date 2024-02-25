namespace toeic_web.Models
{
    public class Vocabulary
    {
        public Guid idVoc { get; set; }
        public Guid idTopic { get; set; }
        public Guid idProfessor { get; set; }
        public string engWord { get; set; }
        public string wordType { get; set; }
        public string meaning { get; set; }
        public virtual VocTopic VocTopic { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
