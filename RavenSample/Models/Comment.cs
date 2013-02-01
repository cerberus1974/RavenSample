using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RavenSample.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Commenter { get; set; }
        public DateTime CreateAt { get; set; }
    }
}