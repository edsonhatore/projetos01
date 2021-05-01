using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HFIT.Services
{
   public abstract class Service
    {
        protected HttpClient _client;
        protected string  BaseApiurl = "http://192.168.15.5/EDSON/HFIT/";

        public Service()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://192.168.15.5/EDSON/HFIT/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


        }



    }

   
}
