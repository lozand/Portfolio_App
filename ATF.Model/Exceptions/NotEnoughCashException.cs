using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATF.Model.Exceptions
{
    public class NotEnoughCashException : Exception
    {
        public NotEnoughCashException() : this("User does not have enough cash to complete this transaction") { }

        public NotEnoughCashException(string message) : base(message) { }

        public NotEnoughCashException(string message, Exception ex) : base(message, ex) { }
    }
}
