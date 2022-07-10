using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Infrastructure
{
    public class PermissionDto
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public PermissionDto(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
    public  interface IPermissionExposer
    {
        Dictionary<string, List<PermissionDto>> Expose();
    }
}
