using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.model
{
    [Serializable]
    public class Animal
    {
        public virtual int Idanimal { get; set; }
        public virtual string Name { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual string Animaltype { get; set; }



    }
}