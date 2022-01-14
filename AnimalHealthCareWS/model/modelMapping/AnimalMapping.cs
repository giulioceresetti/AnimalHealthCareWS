using AnimalHealthCareWS.model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.modelMapping
{
 
    public class AnimalMapping : ClassMap<Animal>
    {
        public AnimalMapping()
        {
            Id(x => x.Idanimal).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Animaltype);
            References(x => x.Owner).Column("IDOWNER");

        }
    }
}