using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace UnapecERPApp.Utils
{
    public sealed class WebApiClient : HttpClient
    {
        private static WebApiClient instance = null;
        private static readonly object padlock = new object();

        WebApiClient()
        {
        }

        public static WebApiClient Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new WebApiClient()
                        {
                            BaseAddress = new Uri("https://localhost:5001"),

                        };

                        //instance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    }
                    return instance;
                }
            }
        }
    }
}