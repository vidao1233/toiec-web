﻿namespace toiec_web.Models
{
    public class CourseModel
    {
        public Guid idCourse { get; set; }
        public Guid idProfessor { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
