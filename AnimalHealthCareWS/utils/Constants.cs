using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalHealthCareWS.utils
{
    public static class Constants
    {
        public const String ERROR_CODE_00 = "00";
        public const String ERROR_MSG_00 = "OK";


        public const String ERROR_CODE_01 = "01";
        public const String ERROR_MSG_01 = "taxid is not correct";

        public const String ERROR_CODE_99 = "99";
        public const String ERROR_MSG_99 = "Unhandled Exception.";

        public const String ERROR_CODE_45 = "45";
        public const String ERROR_MSG_45 = "Owner not found.";


        public const String ERROR_CODE_77 = "77";
        public const String ERROR_MSG_77 = "Payment not correctly ended.";



        public const String ERROR_CODE_88 = "88";
        public const String ERROR_MSG_88 = "Defaulting Owner.";



    }
}