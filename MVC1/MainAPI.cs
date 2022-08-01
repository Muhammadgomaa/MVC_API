using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;


namespace MVC1
{
    public class MainAPI
    {
        public static HttpClient WebAPIcLinet = new HttpClient();

        static MainAPI()
        {
            WebAPIcLinet.BaseAddress = new Uri("http://localhost:1911/");
            WebAPIcLinet.DefaultRequestHeaders.Clear();
            WebAPIcLinet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}