using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AnimalHealthCareWS.exceptions
{
    [Serializable]

    public class OwnerNotFoundException:Exception
    {
        public OwnerNotFoundException()
        {
        }

        public OwnerNotFoundException(string message) : base(message)
        {
        }

        public OwnerNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OwnerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}