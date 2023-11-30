namespace toiec_web.Models
{
    public class TestQuestionUnit
    {
        public Guid idQuestionUnit { get; set; }
        public Guid idTest { get; set; }
        public int numBegin { get; set; }
        public int numEnd { get; set; }
        public string paragraph { get; set; }
        public string audio { get; set; }
        public string image { get; set; }
        public string script { get; set; }
        public string translation { get; set; }
        public virtual Test Tests { get; set; }

    }
}
