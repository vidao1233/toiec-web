﻿namespace toiec_web.Models
{
    public class TestQuestionUnitModel
    {
        public Guid idQuestionUnit { get; set; }
        public Guid idTest { get; set; }
        public int idTestPart { get; set; }
        public string paragraph { get; set; }
        public string audio { get; set; }
        public string image { get; set; }
        public string script { get; set; }
        public string translation { get; set; }
    }
}
