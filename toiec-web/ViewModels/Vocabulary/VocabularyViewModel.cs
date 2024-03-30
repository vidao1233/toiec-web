namespace toeic_web.ViewModels.Vocabulary
{
    public class VocabularyViewModel
    {
        public Guid idVoc { get; set; }
        public Guid idTopic { get; set; }
        public string engWord { get; set; }
        public string? pronunciation { get; set; }
        public string? wordType { get; set; }
        public string meaning { get; set; }
    }
}
