namespace toiec_web.ViewModels.Vocabulary
{
    public class VocabularyViewModel
    {
        public Guid idTopic { get; set; }
        public Guid idVoc { get; set; } 
        public string engWord { get; set; }
        public string wordType { get; set; }
        public string meaning { get; set; }
    }
}
