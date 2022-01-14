using AnimalHealthCareWS.model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.modelMapping
{
    public class ExamTypeMapping : ClassMap<Examtype>
    {
        public ExamTypeMapping()
        {
            Id(x => x.Idexamtype).GeneratedBy.Native();
            Map(x => x.Description);
            Map(x => x.Expense);
        }
    }
}