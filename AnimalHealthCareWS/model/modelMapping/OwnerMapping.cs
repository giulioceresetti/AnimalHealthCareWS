using AnimalHealthCareWS.model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.modelMapping
{
    public class OwnerMapping:ClassMap<Owner>
    {
        public OwnerMapping()
        {
            Id(x => x.Idowner).GeneratedBy.Native();
            Map(x => x.Name);

            Map(x => x.Surname);

            Map(x => x.Unpayed);
            Map(x => x.Taxid).Unique();
            Map(x => x.Payed);

            Map(x => x.Balance);
        }
    }
}