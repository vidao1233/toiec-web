namespace toiec_web.Models
{
    public class Question
    {
        public Guid idQuestion { get; set; }
        public Guid idQuiz { get; set; }
        public Guid idTest { get; set; }
        public Guid idProfessor { get; set; }
        public string content { get; set; }
        public string answer { get; set; }
        public string explaination { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual Test Test { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual ICollection<AnswerQuestion> AnswerQuestions { get; set; }
        public virtual Professor Professor { get; set; }

    }
}
