using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReddIt.API.Models
{
    public class AuthorItem
    {
        public string Id{get;set;}
        public DateTime CreatedDate{get;set;}
        public string Title{get;set;}
        public string Permalink{get;set;}
            
    }
}