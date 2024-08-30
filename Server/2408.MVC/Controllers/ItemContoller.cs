using CommandThird._05_BizDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2408.MVC.Controllers
{
    public class ItemController : Controller 
    {
        public ActionResult Inquiry()
        {
            return View("~/Views/Item/ItemInquiry.cshtml");
        }
    
        public ActionResult Input()
        {
            return View("~/Views/Item/ItemInput.cshtml");
        }

        [HttpGet]
        public ActionResult FindItems(long id)
        {
            ItemService itemService = new ItemService();
            itemService.Select(id);

            return Json(id);
        }
    }
}