using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WEBAPP_API_SP.Helper
{
    public class Service
    {
        public HttpClient Initial() 
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44361/");
            //client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}