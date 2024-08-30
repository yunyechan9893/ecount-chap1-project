using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using _2408.MVC;
using _2408.MVC.Controllers;
using CommandThird._05_BizDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2408.MVC.Tests.Controllers
{
    [TestClass]
    public class ItemControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var id = 1;
            ItemService itemService = new ItemService();
            var result = itemService.Select(id);
            // Assert
            Assert.IsTrue(result.Count() > 0);
        }
    }
}
