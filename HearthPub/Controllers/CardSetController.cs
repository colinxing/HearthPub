using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HearthPub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HearthPub.Controllers
{
    public class CardSetController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
                return View(context.GetAllSets());
            }
            else
            {
                List<CardSet> setlist = new List<CardSet>();
                ViewBag.message = "Please login first";
                return View(setlist);
            }
        }
    }
}
