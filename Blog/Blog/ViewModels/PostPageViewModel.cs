using Blog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.ViewModels
{
    public class PostPageViewModel
    {
        public IEnumerable<Post> Posts {get;set;}
        public User User { get; set; }
    }
}