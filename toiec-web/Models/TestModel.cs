﻿namespace toiec_web.Models
{
    public class TestModel
    {
        public Guid idTest { get; set; }
        public Guid idType { get; set; }
        public Guid idProfessor { get; set; }
        public string name { get; set; }
        public DateTime createDate { get; set; }
        public DateTime useDate { get; set; }
    }
}
