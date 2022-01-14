using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.model
{
    [Serializable]
    public class Owner
    {
        public virtual int Idowner { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Taxid { get; set; }
        public virtual float Unpayed { get; set; }
        public virtual float Payed { get; set; }
        public virtual float Balance { get; set; }




    }
}