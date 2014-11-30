using ReddIt.Model;
using ReddIt.API.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ReddIt.API.Models;
using ReddIt.Provider;

namespace ReddIt.API.Controllers
{
    public class ReddItController : ApiController
    {
        private ModelReddIt db = new ModelReddIt();

        public HttpResponseMessage Get(string domain)
        {

            try
            {
                //Call Reddit
                RedditReader reddit = new RedditReader();
                var result = reddit.Get();

                // Save to db
                RootReddit root = new RootReddit();
                root.data = result.data;
                root.kind = result.kind;
                db.RootReddits.Add(root);
                db.SaveChanges();

                //read & format DB
                var itemsbyauthors = from items in db.NewsItems
                                     where items.domain == domain
                                     group items by items.author into g
                                     select new AuthorModel { author = g.Key, items = g.Select(p => new AuthorItem { Id = p.redditid, CreatedDate = p.createdDate, Title = p.title, Permalink = p.permalink }).ToList() };

                return Request.CreateResponse(HttpStatusCode.OK,itemsbyauthors);
            }
            catch (Exception ex) {
                //TODO better error handling
               return Request.CreateResponse(HttpStatusCode.ServiceUnavailable,"An error occured during the request: "+ex.Message); 
            }
        }
        
    }
    
}
