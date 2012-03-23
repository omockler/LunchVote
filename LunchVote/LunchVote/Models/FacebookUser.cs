using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LunchVote.Models
{
    public class FacebookUser
    {
        public long id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }
}