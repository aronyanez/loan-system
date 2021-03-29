using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LoanSystem.Core.Exceptions
{

        public class Error404 : Exception
        {
        public static readonly Error404 NotFound = new Error404(HttpStatusCode.NotFound);


        public HttpStatusCode HttpStatusCode { get; set; }
            public Error404(HttpStatusCode httpStatusCode)
            {
                HttpStatusCode = httpStatusCode;
            }

        }

}
