﻿namespace toiec_web.ViewModels.Question
{
    public class QuestionUpdateModel
    {
        public Guid idQuiz { get; set; }
        public Guid idUnit { get; set; }
        public Guid idProfessor { get; set; }
        public string content { get; set; }
        public string answer { get; set; }
        public string explaination { get; set; }
    }
}