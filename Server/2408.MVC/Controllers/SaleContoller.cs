using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2408.MVC.Controllers
{
    public class SaleController : Controller
    {
        public ActionResult SaleInquiry()
        {
            return View();
        }

        public ActionResult Input()
        {
            return View("~/Views/Sale/SaleInput.cshtml");
        }

        public ActionResult Search()
        {
            return View("~/Views/Item/itemInquiry.cshtml");
        }
    }
}