using Blog.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class EfDbContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Post> Posts { get; set; }
    }
}