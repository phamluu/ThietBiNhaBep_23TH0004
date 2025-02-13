using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThietBiNhaBep_23TH0004.Controllers
{
    [Authorize(Roles = "admin")]
    public class Dashboard_23TH0004Controller : Controller
    {
        // GET: Dashboard_23TH0004
        public ActionResult Index()
        {
            return View();
        }
    }
}