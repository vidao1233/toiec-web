﻿using toiec_web.Models;

namespace toiec_web.Data
{
    public class TestPart
    {
        public Guid partId {  get; set; }
        public string partName { get; set; }
        public virtual ICollection<TestQuestionUnit> TestQuestionUnits { get; set; }
    }
}
