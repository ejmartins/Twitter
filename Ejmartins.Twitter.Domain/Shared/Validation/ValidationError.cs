using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Domain.Shared.Validation
{
    public class ValidationError
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public ValidationError(string message, int errorCode)
        {
            ErrorCode = errorCode;
            Message = message;
        }

        public ValidationError(string message) : this(message, 0)
        {
        }
    }
}
