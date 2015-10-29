using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class AwardController : Controller
    {
        // GET: Award
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}