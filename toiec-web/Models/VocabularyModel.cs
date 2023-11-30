namespace toiec_web.Models
{
    public class VocabularyModel
    {
        public Guid idVoc { get; set; }
        public Guid idTopic { get; set; }
        public Guid idProfessor { get; set; }
        public string engWord { get; set; }
        public string wordType { get; set; }
        public string meaning { get; set; }
    }
}
