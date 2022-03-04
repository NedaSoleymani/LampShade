using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Application
{
    public class OperationResult
    {
        public bool ISSuccessed { get; set; }
        public string Message { get; set; }
       
        public OperationResult()
        {
            ISSuccessed = false;
        }
        public OperationResult Successed(string message = "عملیات با موفقیت انجام شد.")
        {
            ISSuccessed = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message = "عملیات با موفقیت انجام نشد.")
        {
            ISSuccessed = false;
            Message = message;
            return this;
        }
    }
}
