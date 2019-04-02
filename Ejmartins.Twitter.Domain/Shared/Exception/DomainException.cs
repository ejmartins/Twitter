using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Domain.Shared.Exception
{
    public class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, System.Exception exception) : base(message, exception)
        {
        }
    }
}
