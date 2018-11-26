using System;
using System.Diagnostics.Contracts;
using System.Web;
using HearthPub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HearthInn.Controllers
{
    public class AuthController : Controller
    {
        // GET: /<controller>/
        string _username;
        string _password;

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Getinfo(string username, string password)
        {
            this._username = username;
            this._password = password;
            DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
            if(context.Rigister(_username, _password))
            {
                ViewBag.Message = "Register Successfully";
            }
            else
            {
                ViewBag.Message = "Username Already Existed";
            }
            return View();

        }

        public ActionResult Login(string username, string password)
        {
            this._username = username;
            this._password = password;
            DataContext context = HttpContext.RequestServices.GetService(typeof(HearthPub.Models.DataContext)) as DataContext;
            var res = context.Login(_username, _password);
            if (res)
            {
                HttpContext.Session.SetString("user", _username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid Username or Password!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
