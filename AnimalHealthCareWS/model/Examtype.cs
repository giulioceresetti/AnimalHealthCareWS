using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.model
{
    public class Examtype
    {
        public virtual int Idexamtype { get; set; }
        public virtual string Description { get; set; }
        public virtual float Expense { get; set; }


    }
}