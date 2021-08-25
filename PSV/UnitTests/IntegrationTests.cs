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
            Assert.IsInstanceOfType(result, typeof(OkResult));

        }

        [TestMethod]
        public async Task GetOrderDrugsAsync()
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            IntegrationController controller = new IntegrationController(projectConfiguration);

            IActionResult result = await controller.getOrderDrugs();

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task addOrderDrugsAsync()
        {
            ProjectConfiguration projectConfiguration = new ProjectConfiguration();
            projectConfiguration.DatabaseConfiguration = new DatabaseConfiguration();
            projectConfiguration.DatabaseConfiguration.ConnectionString = "Server=DESKTOP-HEAPRGO\\SQLEXPRESS;Initial Catalog=psvTest;Trusted_Connection=True";

            IntegrationController controller = new IntegrationController(projectConfiguration);

            OrderRequest order = new OrderRequest();

            order.DrugId = 1;
            order.Quantity = 1;


            IActionResult result = await controller.createOrderDrug(order);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

    }
}
