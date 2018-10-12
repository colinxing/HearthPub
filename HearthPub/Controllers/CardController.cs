using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HearthPub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HearthInn.Controllers
{
    public class CardController : Controller
    {
        //GET: /<controller>/
        public ActionResult Index(string set, string player, string name)
        {
            string s = "ori";
            if (set != null)
                s = set;
            string p = "ori";
            if (player != null)
                p = player;
            string n = "ori";
            if (name != null)
                n = name;

            if (HttpContext.Session.GetString("user") != null)
            {
                DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
                return View(context.GetAllCards(s,p,n));
            }
            else
            {
                List<Cards> list = new List<Cards>();
                ViewBag.message = "Please login first";
                return View(list);
            }
        }

        //public ActionResult Getset(string set)
        //{
        //    //this.Index(set);
        //    return Content(set);
        //}

        public ActionResult Detail(string Name)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
            var temp = context.GetDetail(Name);
            if (temp != null)
            {
                return View(temp);
            }
            else
            {
                CardDetails t = new CardDetails();
                ViewBag.Message = "Card Dose Not Exist";
                return View(t);
            }
        }

        public ActionResult Delete(string Dname)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
            context.Delete(Dname);
            return RedirectToAction("Index", "Card");
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult AddCard(CardDetails l)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
            context.Add(l);
            return RedirectToAction("Index", "Card");
        }

        public ActionResult Edit(string Name)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
            var tem = context.GetDetail(Name);
            return View(tem);
        }

        public ActionResult EditCard(CardDetails l)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
            context.Edit(l);
            return RedirectToAction("Index", "Card");

        }
    }
}
