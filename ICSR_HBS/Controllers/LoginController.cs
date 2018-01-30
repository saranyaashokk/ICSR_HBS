using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.ViewModels;
using BusinessLayer;
using System.Data;

namespace ICSR_HBS.Controllers
{
    public class LoginController : Controller
    {
        HBBusinessLayer hbl = new HBBusinessLayer();
        // GET: Login
        [HttpGet]
        public ActionResult login()
        {                       
            return View();
        }

        [HttpPost]
        public ActionResult login(login _login)
        {
            try
            {
                List<login> lsLogin = hbl.lsLogin(_login.userName, _login.passWord).ToList();

                if (lsLogin.Count == 1)
                    return RedirectToAction("Index", "ViewBookings");

                return View();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}