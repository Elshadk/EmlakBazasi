using EmlakBazasi.DAL;
using EmlakBazasi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Mvc;

namespace EmlakBazasi.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginUser(string username, string password)
        {
            string u = username;
            string p = password;
            string name = AuthUser(u, p);
            if (!(String.IsNullOrEmpty(name)))
            {
                Session["UserName"] = name;
                return RedirectToAction("index", "home");
            }
            return RedirectToAction("index", "login");
        }

        public string AuthUser(string username, string password)
        {
            string user = ConfigurationManager.AppSettings["username"].ToString();
            string pass = ConfigurationManager.AppSettings["password"].ToString();

            if (password.Equals(pass) && username.Equals(user))
                return "OK";
            else
                return null;
        }

        public ActionResult LogoutUser()
        {
            try
            {
                Session["UserName"] = null;
                return RedirectToAction("index", "login");
            }
            catch
            {
                return RedirectToAction("index", "login");
            }
        }
    }
}