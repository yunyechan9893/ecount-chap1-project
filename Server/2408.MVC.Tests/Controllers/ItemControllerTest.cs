using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using _2408.MVC;
using _2408.MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2408.MVC.Tests.Controllers
{
    [TestClass]
    public class ItemControllerTest
    {
        [TestMethod]
        public void Index()
        {
            SaleService saleService = new SaleService();
            saleService.Select(id);
            A
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
