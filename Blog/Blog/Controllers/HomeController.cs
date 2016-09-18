using Blog.Models;
using Blog.Models.Entities;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    
    public class HomeController : Controller
    {
        EfDbContext db = new EfDbContext();
        PostPageViewModel ppvm = new PostPageViewModel();
        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Login(UserViewModel uvm)
        {
            if (string.IsNullOrEmpty(uvm.User.Login)
                || string.IsNullOrEmpty(uvm.User.Password)
                || !isPassCorrect(uvm.User.Login, uvm.User.Password))
            {
                return View("FailedLogin");
            }
            else
            {                
                Session["LoginedUserId"] = GetUserId(uvm.User.Login, uvm.User.Password);
                
                ppvm.Posts = db.Posts;
                ppvm.User = GetUserById((int)Session["LoginedUserId"]);

                return View("Page", ppvm);//"logined as:" + GetUserById((int)Session["LoginedUserId"]).LastName + " " + GetUserById((int)Session["LoginedUserId"]).Name;
            } 
        }


        [HttpPost]
        [Authorize]
        public ActionResult PostMessage(string message)
        {
            db.Posts.Add(new Post { Text = message, Time = DateTime.Now, UserId = (int)Session["LoginedUserId"] });
            db.SaveChanges();

            ppvm.Posts = db.Posts;
            ppvm.User = GetUserById((int)Session["LoginedUserId"]);

            return View("Page", ppvm);
        }

        public int GetUserId(string login, string password)
        { 
            int id = 0;
            id = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password).Id;
            return id;
        }
        public bool isPassCorrect(string login, string password)
        {
            bool correct = false;
            foreach (var user in db.Users)
            {
                if(user.Login == login && user.Password== password)
                {
                    correct = true;
                }                   
            }
            return correct;
        }
        public User GetUserById(int id)
        {
            User user;
            user = db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }
    }
}