using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOBD.DATA;
using GOBD.MODEL;
using GOBD.Properties;
using MongoDB.Driver;

namespace GOBD.Controllers
{
    public class HomeController : Controller
    {
        public GOBDContext GobdContext = new GOBDContext();
        
        public ActionResult Index()
        {

            GobdContext = new GOBDContext();
            GobdContext.Database.GetStats();
            return Json(GobdContext.Database.Server.BuildInfo, JsonRequestBehavior.AllowGet);
            //ViewBag.Title = "Home Page";

            //return View();
        }
    }
}
