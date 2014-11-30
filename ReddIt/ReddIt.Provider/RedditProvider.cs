using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Http.Description;
using System.Web.Http;
using ReddIt.Model;

namespace ReddIt.Provider
{
    public class RedditReader
    {
        private string endpoint = "http://www.reddit.com/r/sports.json?limit=100";
        public string EndPoint { get { return endpoint; } set { endpoint = value; } }

        public RootReddit Get()
        {
            using (var client = new HttpClient())
            {
              
                var response = client
                            .GetAsync(EndPoint)
                            .Result;

                if (response.IsSuccessStatusCode)
                {
                    var redditservices = response.Content.ReadAsAsync<RootReddit>();
                    return redditservices.Result;
                }
                else
                {
                    throw new Exception("Error connecting API");
                }
            }
        
        }

    }
}