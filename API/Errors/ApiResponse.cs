using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        
    public ApiResponse(int statusCode,string message= null)
        {
            StatusCode = statusCode;
            Message1 = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Äuthorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors leads to anger.",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message1 { get; set; }


    }
}
