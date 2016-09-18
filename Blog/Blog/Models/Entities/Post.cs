using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public string Text { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}