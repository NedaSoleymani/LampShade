using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Infrastructure
{
    public static class Roles
    {
        public const string Administator = "1";
        public const string SystemUser = "2";
        public const string ContentUploader = "3";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیر سیستم";

                case 3:
                    return "محتواگذار";

                default :
                    return "";
            }
        }
    }
}
