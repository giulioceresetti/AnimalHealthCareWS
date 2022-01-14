using AnimalHealthCareWS.model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.modelMapping
{
    public class ExamMapping: ClassMap<Exam>
    {
        public ExamMapping()
        {
            Id(x => x.Idexam).GeneratedBy.Native();
            Map(x => x.ExamDate).Column("exam_date");
            Map(x => x.Note);
            References(x => x.ExamType).Column("idexamtype");
            References(x => x.Animal).Column("idanimal");
        }
    }
}