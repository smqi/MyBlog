using BlogModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace My_Blog.Controllers
{
    public class PostController : Controller
    {
        private static List<Post> posts = new List<Post>()
        {
            new Post (){id=1,Title ="标题1",Content="内容1"},
            new Post (){id=2,Title ="标题2",Content="内容2"}
        };

        private BlogRepository.MySQL.BlogRepository repository = new BlogRepository.MySQL.BlogRepository();
        // 获取文章列表
        public ActionResult Index()
        {
            ViewBag.Posts = repository.GetAll();

            return View();
        }

        // 获取文章内容
        public ActionResult Get(int id)
        {
            var post = repository.GetAll().Where(p => p.id == id).FirstOrDefault();
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Post = post;
            return View();
        }

           
    }
}