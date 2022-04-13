using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZverGram.Common.Exceptions
{
    public class dbException: Exception
    {
        public dbException(): base()  { }
        public dbException(string message) : base(message) { }
        public dbException(string code, string message) : base(message)
        {
            Code = code;
        }

        public string Code { get; }
    }
}
