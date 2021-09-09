using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Configuration;
using PSV.Controllers;
using PSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public async Task GetDrugsAsync()
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            IntegrationController controller = new IntegrationController(projectConfiguration);
            IActionResult result = await controller.getDrugs();

            OkObjectResult objectResult = result as OkObjectResult;

            String lekovi = objectResult.Value as String;

            lekovi.Contains("lek1");
            lekovi.Contains("lek2");
            lekovi.Contains("lek3");
            lekovi.Contains("lek4");

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(lekovi);


        }

        [TestMethod]
        public async Task GetOrderDrugsAsync()
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            IntegrationController controller = new IntegrationController(projectConfiguration);

            IActionResult result = await controller.getOrderDrugs();
            OkObjectResult objectResult = result as OkObjectResult;

            String lekovi = objectResult.Value as String;

            lekovi.Contains("lek1");
            lekovi.Contains("lek2");
            lekovi.Contains("lek3");
            

            objectResult.StatusCode.Equals(200);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(lekovi);
        }

        [TestMethod]
        public async Task addOrderDrugsAsync()
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";


            IntegrationController controller = new IntegrationController(projectConfiguration);

            OrderRequest req = new OrderRequest();

            req.DrugId = 1;
            req.Quantity = 3;
            

            IActionResult result = await controller.createOrderDrug(req);
           
            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult objectResult = result as OkObjectResult;
            objectResult.StatusCode.Equals(200);
            //kad je prazan string onda je returnovao https status 200

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public async Task GetPurchasePharmacyDrugsTestAsync()
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            IntegrationController controller = new IntegrationController(projectConfiguration);
            IActionResult result = await controller.getPurchasePharmacyDrugs(3,3);
            //lupila neke brojeve

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            OkObjectResult objectResult = result as OkObjectResult;
            objectResult.StatusCode.Equals(200);
            objectResult.Value.Equals(true);
            //Assert.AreEqual(list.Count, 2);

            Assert.IsNotNull(objectResult);
        }


    }
}
