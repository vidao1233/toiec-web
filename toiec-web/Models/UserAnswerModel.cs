namespace toiec_web.Models
{
    public class UserAnswerModel
    {
        public Guid idUAnswer { get; set; }
        public Guid idQuestion { get; set; }
        public Guid idRecord { get; set; }
        public Guid idStudent { get; set; }
        public string userChoice { get; set; }
        public bool state { get; set; }
    }
}
