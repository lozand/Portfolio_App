using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF.Model.Exceptions
{
    public class NotEnoughSharesException : Exception
    {
        public NotEnoughSharesException() : this("User does not have enough shares to complete this transaction") { }

        public NotEnoughSharesException(string message) : base(message) { }

        public NotEnoughSharesException(string message, Exception ex) : base(message, ex) { }
    }
}
