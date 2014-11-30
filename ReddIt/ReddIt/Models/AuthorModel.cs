using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReddIt.API.Models
{
    public class AuthorModel
    {
        public string author { get; set; }
        public List<AuthorItem> items {get;set;}
    }
}