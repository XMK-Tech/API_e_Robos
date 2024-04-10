using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgilleApi.API.ControllersResult.Base
{
    public class StatusResponse
    {
        public int code { get; private set; }
        public string message { get; private set; }
        public bool flag { get; private set; }
        public void setStatus(int statusCode)
        {
            code = statusCode;
            if (statusCode <= 202)
            {
                message = "SUCCESS";
                flag = true;
            }
            if (statusCode == 400 && statusCode < 405 && statusCode != 401)
            {
                message = "INVALID";
                flag = false;

            }
            if (statusCode == 401)
            {
                message = "FORBIDDEN";
                flag = false;

            }
            if (statusCode > 405)
            {
                message = "ERROR";
                flag = false;

            }


        }
    }
}
