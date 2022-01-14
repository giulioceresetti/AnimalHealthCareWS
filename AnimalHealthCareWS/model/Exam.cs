using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.model
{
    public class Exam
    {
        public virtual int Idexam { get; set; }
        public virtual DateTime ExamDate { get; set; }
        public virtual Animal Animal { get; set; }
        public virtual Examtype ExamType { get; set; }
        public virtual string Note { get; set; }

    }
}