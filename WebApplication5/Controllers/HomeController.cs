using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        InstagramContext ic = new InstagramContext();
        // GET: Home
        //Sign In Action.........
        public ActionResult SignIn()
        {
            return View();
        }

        //Sign In and check user is present or not......
        [HttpPost]
        public ActionResult SignIn(Instagram insta)
        {
            if (insta.uname != null && insta.uemail != null && insta.udob != null && insta.ugender != null && insta.upass != null && insta.upass==insta.ucpass)
            {
                if ((ic.Instagrams.FirstOrDefault(c => c.uemail == insta.uemail)) != null)
                {
                    ViewData["SignIn_Err"] = "User Is Already Present........";
                    return View();
                }
                else
                {
                    ic.Instagrams.Add(insta);
                    ic.SaveChanges();
                    return RedirectToAction("LogIn");
                }
            }
            return View();
        }

        //Login Action...........
        public ActionResult LogIn()
        {
            return View();
        }

        //Login and check the user email and password.........
        [HttpPost]
        public ActionResult LogIn(Instagram i)
        {
            if (i.uemail!=null && i.upass!=null)
            {
                //Find the user using email and pass from databse........
                var che = ic.Instagrams.FirstOrDefault(a => a.uemail == i.uemail && a.upass == i.upass);
                if (che != null)
                {
                    FormsAuthentication.SetAuthCookie(i.uemail, false);
                    Session["status"] = i.uemail;
                    return RedirectToAction("Dash");
                }
                else
                {
                    ViewData["err"] = "Invalid Credentials.......";
                    return View();
                }
            }
            return View();
        }

        //Dashboard..........
        [Authorize]
        public ActionResult Dash()
        {
            return View();
        }

        //Log Out Section..........
        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}