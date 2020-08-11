using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WEBAPP_API_SP
{
    public class GlobalVariables
    {
        public static HttpClient webapiClient = new HttpClient();

        static GlobalVariables()
        {
            webapiClient.BaseAddress = new Uri("https://localhost:44361/api/");
            webapiClient.DefaultRequestHeaders.Clear();
            webapiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}