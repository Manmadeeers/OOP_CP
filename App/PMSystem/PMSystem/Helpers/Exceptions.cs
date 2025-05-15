using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSystem.Helpers
{
    public class LogInException:Exception
    {
        public LogInException() { }
        public LogInException(string message) : base(message) { }
    }


    public class SignUpException : Exception
    {
        public SignUpException() { }

        public SignUpException(string message) : base(message) { }
    }
}
