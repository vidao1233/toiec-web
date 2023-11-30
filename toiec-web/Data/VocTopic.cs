namespace toiec_web.Models
{
    public class VocTopic
    {
        public Guid idVocTopic { get; set; }
        public Guid idProfessor { get; set; }
        public string name { get; set; }
        public virtual ICollection<Vocabulary> Vocabularies { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
