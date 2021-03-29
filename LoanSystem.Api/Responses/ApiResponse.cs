using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LoanSystem.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data, HttpStatusCode status)
        {
            Data = data;
            Status = status;
        }

        public T Data { get; set; }

        public HttpStatusCode Status { get; set; }


    }
}
