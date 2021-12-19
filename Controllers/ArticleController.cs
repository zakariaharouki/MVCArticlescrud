using Microsoft.AspNetCore.Mvc;
using MVCArticlescrud.Models;
using Microsoft.AspNetCore.Server;
using System;
using System.Linq;
using System.Data;
using Microsoft.AspNetCore.Hosting.Server;

namespace MVCArticlescrud.Controllers
{
    public class ArticleController : Controller
    {
        ArticlesDatabaseContext articlesDatabaseContext=new ArticlesDatabaseContext();
        public IActionResult Index()
        {
            List<Article> articles = articlesDatabaseContext.Articles.ToList();
            return View(articles);
        }
        public IActionResult Details(int ID)
        {
            Article art = this.articlesDatabaseContext.Articles.Where(a => a.ID == ID).FirstOrDefault();
            return View("Details", art);
        }
        public  IActionResult Create()
        {
            return View();
        }
        //public IActionResult Edit(int ID)
        //{
        //    Article data = this.articlesDatabaseContext.Articles.Where(e => e.ID == ID).FirstOrDefault();
        //    return View("Create",data);
        //}
        [HttpPost]
        public IActionResult Create(Article model)
        {
            ModelState.Remove("ID");
            if (ModelState.IsValid)
            {

                articlesDatabaseContext.Articles.Add(model);
                articlesDatabaseContext.SaveChanges();
                return RedirectToAction("Index");
                //if (model.image != null && model.image.Length > 0)
                //{
                //    var uploadDir = "~/images/Games/"; // your location for save images
                //    string image = Guid.NewGuid().ToString() + model.image;
                //    var imagePath = Path.Combine(Server.MapPath(uploadDir), image);
                //    image.SaveAs(imagePath);
                //    model.image = image;
                //}

            }
            return View();
        }
        public IActionResult Edit(int ID)
        {
            Article art=this.articlesDatabaseContext.Articles.Where(a=>a.ID==ID).FirstOrDefault();
            return View("Create", art);
        }
        [HttpPost]
        public IActionResult Edit(Article article)
        {
            ModelState.Remove("ID");
            if (ModelState.IsValid)
            {
                articlesDatabaseContext.Articles.Update(article);
                articlesDatabaseContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", article);
        }
        public IActionResult Delete(int ID)
        {
            Article art = this.articlesDatabaseContext.Articles.Where(a => a.ID == ID).FirstOrDefault();
            if (art != null)
            {
                articlesDatabaseContext.Remove(art);
                articlesDatabaseContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
