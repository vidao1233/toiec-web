namespace toiec_web.Models
{
    public class TestRecord
    {
        public Guid idRecord { get; set; }
        public Guid idTest { get; set; }
        public Guid idStudent { get; set; }
        public DateTime createDate { get; set; }
        public double score { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual Student Student { get; set; }
    }
}
