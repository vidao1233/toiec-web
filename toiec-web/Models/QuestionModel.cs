﻿namespace toiec_web.Models
{
    public class QuestionModel
    {
        public Guid idQuestion { get; set; }
        public Guid idQuiz { get; set; }
        public Guid idUnit { get; set; }
        public Guid idProfessor { get; set; }
        public string content { get; set; }
        public string answer { get; set; }
        public string explaination { get; set; }
    }
}