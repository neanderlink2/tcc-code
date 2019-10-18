using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramAcad.PoC.Compiler.JDoodle.Models
{
    public class CompilingFailedException : Exception
    {
        public CompilingFailedException(ErrorResponse response)
        {
            Response = response;
        }

        public CompilingFailedException(string error, int statusCode)
        {
            Response = new ErrorResponse()
            {
                Error = error,
                StatusCode = statusCode
            };
        }

        public ErrorResponse Response { get; private set; }
    }
}
